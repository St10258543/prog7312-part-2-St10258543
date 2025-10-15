using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MunicipalityApp.Data;
using MunicipalityApp.Models;

namespace MunicipalityApp.Controllers
{
    public class EventsController : Controller
    {
    
        // Predefined event categories for filtering
        private readonly List<string> _categoryOptions = new()
        {
            "Community", "Government", "Education", "Environment", "Health",
            "Safety", "Sports", "Infrastructure", "Culture", "Technology",
            "Transport", "Employment"
        };

        // GET: /Events/Index
        // Displays the main events page with search, filter, and sort.
        [HttpGet]
        public IActionResult Index(string? searchTerm, string? CategoryFilter, DateTime? eventDate, string? sortBy)
        {
            // Retrieve all events from the custom priority queue
            var events = MunicipalityData.EventsQueue.GetAllElements();

            // 2Retrieve announcements grouped by category
            var announcementsDict = new Dictionary<string, List<Announcements>>();
            foreach (var key in MunicipalityData.AnnouncementsByCategory.Keys)
                announcementsDict[key] = MunicipalityData.AnnouncementsByCategory[key];

            // Search functionality
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                events = events
                    .Where(e => e.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                             || e.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                             || e.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Log the category of the first matching event for personalized recommendations
                var matchedCategory = events.FirstOrDefault()?.Category;
                MunicipalityData.LogUserCategory(matchedCategory);
            }

            // Retrieve top recommended events based on user’s category interest
            var recommendations = MunicipalityData.GetRecommendedEvents(5);

            // Filter events by selected category
            if (!string.IsNullOrWhiteSpace(CategoryFilter))
            {
                events = events
                    .Where(e => e.Category.Equals(CategoryFilter, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Filter events by specific date
            if (eventDate.HasValue)
            {
                events = events
                    .Where(e => e.Date.Date == eventDate.Value.Date)
                    .ToList();
            }

            // Sorting logic
            events = sortBy?.ToLower() switch
            {
                "date" => events.OrderBy(e => e.Date).ToList(),
                "category" => events.OrderBy(e => e.Category, StringComparer.OrdinalIgnoreCase).ToList(),
                "title" => events.OrderBy(e => e.Title).ToList(),
                _ => events.OrderBy(e => e.Date).ToList()
            };

            // Retrieve recently viewed events
            var recentlyViewed = MunicipalityData.RecentlyViewedEvents.ToList();

            // Build the ViewModel for the view
            var model = new EventsViewModel
            {
                SearchTerm = searchTerm,
                CategoryFilter = CategoryFilter,
                EventDate = eventDate,
                Categories = new SelectList(_categoryOptions, CategoryFilter)
            };

            // Pass data to the View via ViewData and ViewBag
            ViewData["Events"] = events;
            ViewData["Announcements"] = announcementsDict;
            ViewData["RecentlyViewed"] = recentlyViewed;
            ViewBag.SortBy = sortBy;
            ViewBag.Recommended = recommendations;

            // Return the populated view
            return View(model);
        }

        // GET: /Events/ViewEvent/{id}
        // Displays details for a specific event and updates recommendations.
        [HttpGet]
        public IActionResult ViewEvent(int id)
        {
            // Retrieve all events
            var allEvents = MunicipalityData.EventsQueue.GetAllElements();

            // Find event by its unique ID
            var selectedEvent = allEvents.FirstOrDefault(e => e.Id == id);

            if (selectedEvent != null)
            {
                // Add event to the recently viewed stack
                MunicipalityData.RecentlyViewedEvents.Push(selectedEvent);

                // Log viewed event category 
                MunicipalityData.LogUserCategory(selectedEvent.Category);
            }

            return View(selectedEvent);
        }

        // GET: /Events/Search
        // Handles search requests and redirects to Index with results.
        [HttpGet]
        public IActionResult Search(string query)
        {
            // Log search term for analytics and personalized suggestions
            MunicipalityData.LogUserSearch(query);

            // Redirect to Index with the search term parameter
            return RedirectToAction("Index", new { searchTerm = query });
        }
    }
}
