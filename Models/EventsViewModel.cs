using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace MunicipalityApp.Models
{
    public class EventsViewModel
    {
        public string? SearchTerm { get; set; }
        public string? CategoryFilter { get; set; }
        public DateTime? EventDate { get; set; }

        public SelectList? Categories { get; set; } // For dropdown
    }
}
