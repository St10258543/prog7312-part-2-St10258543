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
       
        // List of available event categories for dropdown selection
        private readonly List<string> _categoryOptions = new()
        {
            "Community", "Government", "Education", "Environment", "Health",
            "Safety", "Sports", "Infrastructure", "Culture", "Technology",
            "Transport", "Employment"
        };

        
        // GET: /Events/Index
        [HttpGet]
        public IActionResult Index(
            string? searchTerm,
            string? CategoryFilter,
            DateTime? eventDate,
            string? sortBy)
        {
            // Retrieve all events from the queue
            var events = MunicipalityData.EventsQueue?
                .UnorderedItems
                .Select(e => e.Element)
                .ToList() ?? new List<Events>();

            // Retrieve announcements
            var announcements = MunicipalityData.AnnouncementsByCategory 
                                ?? new Dictionary<string, List<Announcements>>();

            // Search functionality
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                events = events
                    .Where(e => e.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                             || e.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                             || e.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Log user search for analytics or recommendations
                MunicipalityData.LogUserSearchFromQuery(searchTerm);
            }

        
            // Filter by category
            if (!string.IsNullOrWhiteSpace(CategoryFilter))
            {
                events = events
                    .Where(e => e.Category.Equals(CategoryFilter, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Filter by event date
            if (eventDate.HasValue)
            {
                events = events
                    .Where(e => e.Date.Date == eventDate.Value.Date)
                    .ToList();
            }
            // Sorting logic
            // ==========================
            events = sortBy?.ToLower() switch
            {
                "date" => events.OrderBy(e => e.Date).ToList(),
                "category" => events.OrderBy(e => e.Category, StringComparer.OrdinalIgnoreCase).ToList(),
                "title" => events.OrderBy(e => e.Title).ToList(),
                _ => events.OrderBy(e => e.Date).ToList()
            };

            // ==========================
            // Recommendations & Recently Viewed
            // ==========================
            var recommendations = MunicipalityData.GetRecommendedEvents(5); // configurable number of recommendations
            var recentlyViewed = MunicipalityData.RecentlyViewedEvents.ToList();

            // ==========================
            // Build the ViewModel
            // ==========================
            var model = new EventsViewModel
            {
                SearchTerm = searchTerm,
                CategoryFilter = CategoryFilter,
                EventDate = eventDate,
                Categories = new SelectList(_categoryOptions, CategoryFilter)
            };

            // ==========================
            // Pass data to View
            // ==========================
            ViewData["Events"] = events;
            ViewData["Announcements"] = announcements;
            ViewData["RecentlyViewed"] = recentlyViewed;
            ViewBag.Recommended = recommendations;
            ViewBag.SortBy = sortBy;

            return View(model);
        }

        // ==========================
        // GET: /Events/ViewEvent/{id}
        // ==========================
        [HttpGet]
        public IActionResult ViewEvent(int id)
        {
            // Retrieve all events
            var allEvents = MunicipalityData.EventsQueue?
                .UnorderedItems
                .Select(e => e.Element)
                .ToList() ?? new List<Events>();

            // Find the event by ID
            var selectedEvent = allEvents.FirstOrDefault(e => e.Id == id);

            // Track as recently viewed
            if (selectedEvent != null)
            {
                MunicipalityData.RecentlyViewedEvents.Push(selectedEvent);
            }

            return View(selectedEvent);
        }

        // ==========================
        // GET: /Events/Search
        // Redirects to Index with search query
        // ==========================
        [HttpGet]
        public IActionResult Search(string query)
        {
            return RedirectToAction("Index", new { searchTerm = query });
        }
    }
}
