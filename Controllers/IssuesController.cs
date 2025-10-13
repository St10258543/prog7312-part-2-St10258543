using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Models;
using MunicipalityApp.Data;
using MunicipalityApp.DataStructures; // <- for CustomIssues
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System.Linq;
using System.Collections.Generic;

namespace MunicipalityApp.Controllers
{
    public class IssuesController : Controller
    {
        private readonly ILogger<IssuesController> _logger;
        private readonly IReportRepository _reportRepository;
        private readonly IStringLocalizer<IssuesController> _localizer;

        // Constructor: inject logger and repository
        public IssuesController(ILogger<IssuesController> logger, IReportRepository reportRepository, IStringLocalizer<IssuesController> localizer)
        {
            _logger = logger;
            _reportRepository = reportRepository;
            _localizer = localizer;
        }

        // GET: /Issues
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "Issues"; 
            return View();
        }

        // POST: /Issues/SubmitReport
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitReport(
            string location, 
            string category, 
            string description, 
            IFormFile? media)
        {
            // List to store uploaded file names
            List<string> mediaFiles = new List<string>();

            // Save uploaded file to wwwroot/uploads
            if (media != null && media.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                
                // Create uploads directory if it doesn't exist
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                var fileName = Path.GetFileName(media.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await media.CopyToAsync(stream);
                }

                mediaFiles.Add(fileName);
            }

            // Create a new issue object
            var issue = new Issues
            {
                Location = location,
                Category = category,
                Description = description,
                MediaFileName = mediaFiles.Count > 0 ? string.Join(",", mediaFiles) : null,
                Status = "Pending",
                DateSubmitted = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "South Africa Standard Time")
            };

            // Save the issue to the repository (MongoDB)
            await _reportRepository.CreateAsync(issue);

            // Saves the issue in memory using custom linked list
            CustomIssues.IssuesList.Add(issue);
            
            TempData["SuccessMessage"] = _localizer["ReportSubmittedMessage"].ToString();

            return RedirectToAction("Index");
        }

        // GET: /Issues/Status
        [HttpGet]
        public async Task<IActionResult> Status()
        {
            ViewData["ActivePage"] = "ViewReports";

            // Retrieve all reports from repository
            var dbReports = await _reportRepository.GetAllAsync();

            // Retrieve all reports from in-memory linked list
            var memoryReports = CustomIssues.IssuesList.GetAll();

            // Combine database and in-memory issues, removing duplicates by Id
            var combinedReports = dbReports.Concat(memoryReports)
                                           .GroupBy(i => i.Id) // Assumes Issues has Id property
                                           .Select(g => g.First())
                                           .ToList();

            return View(combinedReports);
        }

        // GET: /Issues/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // GET: /Issues/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }
    }
}