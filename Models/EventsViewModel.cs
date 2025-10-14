using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace MunicipalityApp.Models
{
    public class EventsViewModel
    {
        /// A keyword or phrase entered by the user to search for events by title or description.
        public string? SearchTerm { get; set; }

        // The selected category used to filter events (e.g., "Community", "Cultural").
        public string? CategoryFilter { get; set; }

        // The selected date used to filter events by a specific day.
        public DateTime? EventDate { get; set; }

        // A list of available categories for the dropdown menu in the view.
        public SelectList? Categories { get; set; }
    }
}
