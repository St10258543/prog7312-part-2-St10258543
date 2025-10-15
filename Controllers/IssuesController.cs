using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Models;
using MunicipalityApp.Data;
using MunicipalityApp.DataStructures;
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

        // Constructor: inject logger, repository, and localizer for messages
        public IssuesController(ILogger<IssuesController> logger, IReportRepository reportRepository, IStringLocalizer<IssuesController> localizer)
        {
            _logger = logger;
            _reportRepository = reportRepository;
            _localizer = localizer;
        }

        // GET: /Issues
        // Displays the main issues page
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "Issues"; 
            return View();
        }

        // POST: /Issues/SubmitReport
        // Handles form submission for new issue reports, including media upload
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

            // If media file uploaded, save to wwwroot/uploads
            if (media != null && media.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                
                // Ensure uploads directory exists
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                // Save uploaded file
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

            // Save issue to persistent storage (MongoDB repository)
            await _reportRepository.CreateAsync(issue);

            // Save issue in in-memory custom linked list for fast access
            CustomIssues.IssuesList.Add(issue);

            TempData["SuccessMessage"] = _localizer["ReportSubmittedMessage"].ToString();

            return RedirectToAction("Index");
        }

        // GET: /Issues/Status
        // Displays all submitted reports, combining database and in-memory
        [HttpGet]
        public async Task<IActionResult> Status()
        {
            ViewData["ActivePage"] = "ViewReports"; 

            // Retrieve all reports from persistent storage
            var dbReports = await _reportRepository.GetAllAsync();

            // Retrieve all reports from in-memory linked list
            var memoryReports = CustomIssues.IssuesList.GetAll().ToList();

            // Combine database and in-memory reports, removing duplicates by Id
            var combinedReports = dbReports.Concat(memoryReports)
                                           .GroupBy(i => i.Id)
                                           .Select(g => g.First())
                                           .ToList();

            return View(combinedReports);
        }

        // GET: /Issues/Privacy
        // Displays the privacy policy page
        public IActionResult Privacy()
        {
            return View();
        }

        // GET: /Issues/Error
        // Displays the error page with request ID
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
