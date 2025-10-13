using MunicipalityApp.Models;

namespace MunicipalityApp.Data
{
    public static class MunicipalityData
    {
        // Priority queue for events (earliest date first)
        public static PriorityQueue<Events, DateTime> EventsQueue { get; } = new();

        // Dictionary for announcements grouped by category
        public static Dictionary<string, List<Announcements>> AnnouncementsByCategory { get; } = new();

        // Track user search interests
        public static Dictionary<string, int> UserSearchPreferences { get; } = new();

        // Sets to keep unique categories
        public static HashSet<string> EventCategories { get; } = new();
        public static HashSet<string> AnnouncementCategories { get; } = new();
        public static Stack<Events> RecentlyViewedEvents { get; } = new();

        // ✅ Constructor (runs once at app startup)
        static MunicipalityData()
        {
            // ==============================
            // Seed sample events
            // ==============================
            var events = new List<Events>
            {
                new() { Id = 1, Title = "Town Hall Meeting", Description = "Monthly community meeting to discuss local developments.", Date = DateTime.Parse("2025-10-05"), Category = "Government" },
                new() { Id = 2, Title = "Park Clean-up", Description = "Community clean-up event at Central Park.", Date = DateTime.Parse("2025-10-12"), Category = "Community" },
                new() { Id = 3, Title = "Beach Clean-up", Description = "Join us for a coastal clean-up to keep our beaches beautiful.", Date = DateTime.Parse("2025-10-17"), Category = "Environment" },
                new() { Id = 4, Title = "Blood Donation Drive", Description = "Support the community by donating blood at the Civic Centre.", Date = DateTime.Parse("2025-10-20"), Category = "Health" },
                new() { Id = 5, Title = "Fire Safety Workshop", Description = "Learn basic fire safety and prevention tips from experts.", Date = DateTime.Parse("2025-10-22"), Category = "Safety" },
                new() { Id = 6, Title = "Farmers Market", Description = "Local farmers market featuring organic produce and crafts.", Date = DateTime.Parse("2025-10-25"), Category = "Community" },
                new() { Id = 7, Title = "Youth Sports Festival", Description = "Annual youth sports and recreation day at Riverside Stadium.", Date = DateTime.Parse("2025-11-01"), Category = "Sports" },
                new() { Id = 8, Title = "Municipal Budget Presentation", Description = "Public presentation of the annual municipal budget.", Date = DateTime.Parse("2025-11-05"), Category = "Government" },
                new() { Id = 9, Title = "Road Safety Awareness Campaign", Description = "Interactive session on road safety and traffic awareness.", Date = DateTime.Parse("2025-11-08"), Category = "Safety" },
                new() { Id = 10, Title = "Tree Planting Drive", Description = "Help us plant 500 new trees in Greenfield Park.", Date = DateTime.Parse("2025-11-12"), Category = "Environment" },
                new() { Id = 11, Title = "Senior Citizens Day", Description = "A fun day celebrating our senior residents with music and games.", Date = DateTime.Parse("2025-11-15"), Category = "Community" },
                new() { Id = 12, Title = "Electricity Infrastructure Upgrade", Description = "Presentation on upcoming power grid upgrades.", Date = DateTime.Parse("2025-11-18"), Category = "Infrastructure" },
                new() { Id = 13, Title = "Public Library Reading Fair", Description = "Storytime, author meetups, and book donations.", Date = DateTime.Parse("2025-11-20"), Category = "Education" },
                new() { Id = 14, Title = "Local Art Exhibition", Description = "Showcasing artwork by local painters and sculptors.", Date = DateTime.Parse("2025-11-25"), Category = "Culture" },
                new() { Id = 15, Title = "Community Safety Patrol Launch", Description = "Launch of the new neighborhood watch program.", Date = DateTime.Parse("2025-11-28"), Category = "Safety" },
                new() { Id = 16, Title = "Flood Awareness Workshop", Description = "Learn how to prepare for flood emergencies.", Date = DateTime.Parse("2025-12-02"), Category = "Environment" }
            };

            foreach (var ev in events)
            {
                EventsQueue.Enqueue(ev, ev.Date);
                EventCategories.Add(ev.Category);
            }

            // ==============================
            // Seed sample announcements
            // ==============================
            var announcements = new List<Announcements>
            {
                new() { Id = 1, Title = "Water Disruption", Message = "Water supply will be disrupted in the downtown area on Oct 7.", DatePosted = DateTime.Now, Category = "Service Update" },
                new() { Id = 2, Title = "New Clinic Opening", Message = "The Greenfield Clinic will open to the public on Oct 20.", DatePosted = DateTime.Now, Category = "Health" },
                new() { Id = 3, Title = "Electricity Maintenance", Message = "Scheduled power maintenance in the East Zone on Oct 25.", DatePosted = DateTime.Now, Category = "Infrastructure" },
                new() { Id = 4, Title = "Road Closure Notice", Message = "Main Street will be closed for repairs from Oct 15–18.", DatePosted = DateTime.Now, Category = "Traffic" },
                new() { Id = 5, Title = "Community Centre Renovation", Message = "Community Centre will be closed for upgrades until Nov 10.", DatePosted = DateTime.Now, Category = "Community" },
                new() { Id = 6, Title = "Scholarship Applications Open", Message = "Students can now apply for the 2025 municipal scholarships.", DatePosted = DateTime.Now, Category = "Education" },
                new() { Id = 7, Title = "Waste Collection Schedule", Message = "Updated waste collection schedule effective Nov 1.", DatePosted = DateTime.Now, Category = "Environment" },
                new() { Id = 8, Title = "New Traffic Cameras Installed", Message = "Traffic cameras now operational on Elm and Pine Streets.", DatePosted = DateTime.Now, Category = "Safety" },
                new() { Id = 9, Title = "Public Wi-Fi Expansion", Message = "Free municipal Wi-Fi now available in city parks.", DatePosted = DateTime.Now, Category = "Technology" },
                new() { Id = 10, Title = "Emergency Hotline Update", Message = "New toll-free emergency contact number launched.", DatePosted = DateTime.Now, Category = "Safety" },
                new() { Id = 11, Title = "Job Fair Announcement", Message = "Attend the Municipal Job Fair on Nov 15 at the Civic Hall.", DatePosted = DateTime.Now, Category = "Employment" },
                new() { Id = 12, Title = "COVID-19 Booster Clinics", Message = "Free booster shots available at local health centres.", DatePosted = DateTime.Now, Category = "Health" },
                new() { Id = 13, Title = "Recycling Program Update", Message = "Glass recycling collection to resume from Nov 10.", DatePosted = DateTime.Now, Category = "Environment" },
                new() { Id = 14, Title = "Public Transport Schedule", Message = "Revised bus and train timetables effective Dec 1.", DatePosted = DateTime.Now, Category = "Transport" },
                new() { Id = 15, Title = "Mayor’s Holiday Message", Message = "The Mayor extends warm wishes for the festive season.", DatePosted = DateTime.Now, Category = "Government" }
            };

            foreach (var ann in announcements)
            {
                if (!AnnouncementsByCategory.ContainsKey(ann.Category))
                    AnnouncementsByCategory[ann.Category] = new List<Announcements>();

                AnnouncementsByCategory[ann.Category].Add(ann);
                AnnouncementCategories.Add(ann.Category);
            }
        }

        // ✅ Logs user search preferences
        public static void LogUserSearch(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return;

            if (UserSearchPreferences.ContainsKey(category))
                UserSearchPreferences[category]++;
            else
                UserSearchPreferences[category] = 1;
        }
        // Logs all categories found in a search query
public static void LogUserSearchFromQuery(string query)
{
    if (string.IsNullOrWhiteSpace(query))
        return;

    // Find all categories that match parts of the query
    var matchedCategories = EventCategories
        .Where(c => query.IndexOf(c, StringComparison.OrdinalIgnoreCase) >= 0);

    foreach (var category in matchedCategories)
    {
        LogUserSearch(category);
    }
}


        // ✅ Retrieves recommended events based on searches
        public static List<Events> GetRecommendedEvents(int count = 3)
        {
            if (UserSearchPreferences.Count == 0)
                return EventsQueue.UnorderedItems.Select(e => e.Element).Take(count).ToList();

            var topCategories = UserSearchPreferences
                .OrderByDescending(kv => kv.Value)
                .Take(2)
                .Select(kv => kv.Key)
                .ToList();

            var recommendations = EventsQueue.UnorderedItems
                .Select(e => e.Element)
                .Where(ev => topCategories.Contains(ev.Category))
                .Take(count)
                .ToList();

            return recommendations;
        }
    }
}
