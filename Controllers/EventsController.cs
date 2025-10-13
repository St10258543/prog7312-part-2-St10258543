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
        // Available categories for dropdown
        private readonly List<string> _categoryOptions = new List<string> 
        { 
            "Community", "Government", "Education", "Environment", "Health", "Safety", "Sports", "Infrastructure", "Culture", "Technology", "Transport", "Employment" 
        };

        [HttpGet]
        public IActionResult Index(
            string? searchTerm, 
            string? CategoryFilter, 
            DateTime? eventDate, 
            string? sortBy)
        {
            // Get all events from the queue
            var events = MunicipalityData.EventsQueue?
                .UnorderedItems
                .Select(e => e.Element)
                .ToList() ?? new List<Events>();

            var announcements = MunicipalityData.AnnouncementsByCategory ?? new Dictionary<string, List<Announcements>>();

            // ===== SEARCH =====
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                events = events
                    .Where(e => e.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                             || e.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                             || e.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Log searched categories
                MunicipalityData.LogUserSearchFromQuery(searchTerm);
            }

            // ===== FILTER =====
            if (!string.IsNullOrWhiteSpace(CategoryFilter))
            {
                events = events
                    .Where(e => e.Category.Equals(CategoryFilter, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (eventDate.HasValue)
            {
                events = events
                    .Where(e => e.Date.Date == eventDate.Value.Date)
                    .ToList();
            }

            // ===== SORT =====
            events = sortBy?.ToLower() switch
            {
                "date" => events.OrderBy(e => e.Date).ToList(),
                "category" => events.OrderBy(e => e.Category, StringComparer.OrdinalIgnoreCase).ToList(),
                "title" => events.OrderBy(e => e.Title).ToList(),
                _ => events.OrderBy(e => e.Date).ToList()
            };

            // ===== RECOMMENDATIONS =====
            var recommendations = MunicipalityData.GetRecommendedEvents(5); // configurable count

            // ===== RECENTLY VIEWED =====
            var recentlyViewed = MunicipalityData.RecentlyViewedEvents.ToList();

            // Build ViewModel
            var model = new EventsViewModel
            {
                SearchTerm = searchTerm,
                CategoryFilter = CategoryFilter,
                EventDate = eventDate,
                Categories = new SelectList(_categoryOptions, CategoryFilter)
            };

            // Pass data to view via ViewData/ViewBag
            ViewData["Events"] = events;
            ViewData["Announcements"] = announcements;
            ViewData["RecentlyViewed"] = recentlyViewed;
            ViewBag.Recommended = recommendations;
            ViewBag.SortBy = sortBy;

            return View(model);
        }

        [HttpGet]
        public IActionResult ViewEvent(int id)
        {
            var allEvents = MunicipalityData.EventsQueue?.UnorderedItems.Select(e => e.Element).ToList() ?? new List<Events>();
            var ev = allEvents.FirstOrDefault(e => e.Id == id);

            if (ev != null)
            {
                MunicipalityData.RecentlyViewedEvents.Push(ev);
            }

            return View(ev);
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            // Redirect to Index with search query
            return RedirectToAction("Index", new { searchTerm = query });
        }
    }
}
