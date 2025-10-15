using MunicipalityApp.Models;
using System;
using System.Collections.Generic;
using MunicipalityApp.DataStructures;

namespace MunicipalityApp.Data
{
    public static class MunicipalityData
    {
        // Custom data structures for events and announcements
        public static CustomPriorityQueue<Events> EventsQueue { get; } = new(); // Priority queue of events (sorted by date)
        public static CustomDictionary<string, List<Announcements>> AnnouncementsByCategory { get; } = new(); // Announcements grouped by category
        public static CustomDictionary<string, int> UserSearchPreferences { get; } = new(); // Tracks user searches and preferences
        public static CustomStack<Events> RecentlyViewedEvents { get; } = new(); // Stack for recently viewed events
        public static CustomHashSet<string> EventCategories { get; } = new(); // Unique event categories
        public static CustomHashSet<string> AnnouncementCategories { get; } = new(); // Unique announcement categories

        // Static constructor: seeds initial data
        static MunicipalityData()
        {
            SeedEvents();       
            SeedAnnouncements(); 
        }

        // Seed Events
        private static void SeedEvents()
        {
            var events = new List<Events>
            {
                // Sample events with ID, title, description, date, and category
                new() { Id = 1, Title = "Cape Town Environmental Awareness Day", Description = "Join local NGOs for workshops on sustainability.", Date = DateTime.Parse("2025-10-05"), Category = "Environment" },
                new() { Id = 2, Title = "Johannesburg Youth Sports Festival", Description = "Annual sports event for youth at Ellis Park.", Date = DateTime.Parse("2025-10-08"), Category = "Sports" },
                new() { Id = 3, Title = "Durban Beach Clean-up", Description = "Volunteers help clean up Durban's beaches.", Date = DateTime.Parse("2025-10-12"), Category = "Community" },
                new() { Id = 4, Title = "Pretoria Municipal Budget Presentation", Description = "Public presentation of the annual municipal budget.", Date = DateTime.Parse("2025-10-15"), Category = "Government" },
                new() { Id = 5, Title = "Soweto Cultural Festival", Description = "Celebration of local arts, music, and food.", Date = DateTime.Parse("2025-10-20"), Category = "Culture" },
                new() { Id = 6, Title = "Bloemfontein Fire Safety Workshop", Description = "Fire safety training for residents.", Date = DateTime.Parse("2025-10-22"), Category = "Safety" },
                new() { Id = 7, Title = "Cape Town Farmers Market", Description = "Local produce and crafts on sale.", Date = DateTime.Parse("2025-10-25"), Category = "Community" },
                new() { Id = 8, Title = "Durban Blood Donation Drive", Description = "Donate blood at the Civic Centre.", Date = DateTime.Parse("2025-10-28"), Category = "Health" },
                new() { Id = 9, Title = "Johannesburg Road Safety Awareness Campaign", Description = "Interactive session on road safety.", Date = DateTime.Parse("2025-11-01"), Category = "Safety" },
                new() { Id = 10, Title = "Pretoria Tree Planting Drive", Description = "Plant 500 new trees in city parks.", Date = DateTime.Parse("2025-11-05"), Category = "Environment" },
                new() { Id = 11, Title = "Cape Town Senior Citizens Day", Description = "Fun activities for senior residents.", Date = DateTime.Parse("2025-11-08"), Category = "Community" },
                new() { Id = 12, Title = "Durban Public Library Reading Fair", Description = "Storytime and book donations.", Date = DateTime.Parse("2025-11-12"), Category = "Education" },
                new() { Id = 13, Title = "Johannesburg Art Exhibition", Description = "Exhibition of local artists' work.", Date = DateTime.Parse("2025-11-15"), Category = "Culture" },
                new() { Id = 14, Title = "Pretoria Youth Entrepreneurship Workshop", Description = "Workshop for aspiring young entrepreneurs.", Date = DateTime.Parse("2025-11-18"), Category = "Education" },
                new() { Id = 15, Title = "Cape Town Community Safety Patrol Launch", Description = "Launch of neighborhood watch program.", Date = DateTime.Parse("2025-11-20"), Category = "Safety" },
                new() { Id = 16, Title = "Durban Coastal Flood Awareness Workshop", Description = "Learn how to prepare for coastal flooding.", Date = DateTime.Parse("2025-11-22"), Category = "Environment" },
                new() { Id = 17, Title = "Soweto Local Job Fair", Description = "Job opportunities and career advice.", Date = DateTime.Parse("2025-11-25"), Category = "Employment" },
                new() { Id = 18, Title = "Pretoria Public Wi-Fi Launch", Description = "Free Wi-Fi in municipal parks and libraries.", Date = DateTime.Parse("2025-11-28"), Category = "Technology" },
                new() { Id = 19, Title = "Cape Town Emergency Preparedness Drill", Description = "Simulated emergency response exercise.", Date = DateTime.Parse("2025-12-01"), Category = "Safety" },
                new() { Id = 20, Title = "Durban Infrastructure Upgrade Presentation", Description = "Upcoming power and water grid upgrades.", Date = DateTime.Parse("2025-12-05"), Category = "Infrastructure" },
                
              
            };

            // Add events to priority queue and track categories
            foreach (var ev in events)
            {
                EventsQueue.Enqueue(ev, ev.Date); // Use date as priority
                EventCategories.Add(ev.Category); // Add to unique category set
            }
        }

        // ==============================
        // Seed Announcements
        // ==============================
        private static void SeedAnnouncements()
        {
            var announcements = new List<Announcements>
            {
                // Sample announcements with ID, title, message, date, and category
                new() { Id = 1, Title = "Water Disruption in Cape Town", Message = "Water supply disruption in CBD on Oct 7.", DatePosted = DateTime.Now, Category = "Service Update" },
                new() { Id = 2, Title = "New Clinic Opening in Soweto", Message = "Greenfield Clinic opens Oct 20.", DatePosted = DateTime.Now, Category = "Health" },
                new() { Id = 3, Title = "Electricity Maintenance in Durban", Message = "Scheduled maintenance on Oct 25.", DatePosted = DateTime.Now, Category = "Infrastructure" },
                new() { Id = 4, Title = "Road Closure Notice in Pretoria", Message = "Main Street closed Oct 15–18.", DatePosted = DateTime.Now, Category = "Traffic" },
                new() { Id = 5, Title = "Community Centre Renovation", Message = "Community Centre closed until Nov 10.", DatePosted = DateTime.Now, Category = "Community" },
                new() { Id = 6, Title = "Scholarship Applications Open", Message = "Apply for 2025 municipal scholarships.", DatePosted = DateTime.Now, Category = "Education" },
                new() { Id = 7, Title = "Waste Collection Update", Message = "New waste collection schedule effective Nov 1.", DatePosted = DateTime.Now, Category = "Environment" },
                new() { Id = 8, Title = "New Traffic Cameras", Message = "Cameras operational on major streets.", DatePosted = DateTime.Now, Category = "Safety" },
                new() { Id = 9, Title = "Public Wi-Fi Expansion", Message = "Free Wi-Fi in city parks.", DatePosted = DateTime.Now, Category = "Technology" },
                new() { Id = 10, Title = "Emergency Hotline Update", Message = "New toll-free emergency number launched.", DatePosted = DateTime.Now, Category = "Safety" },
                new() { Id = 11, Title = "Job Fair in Johannesburg", Message = "Attend the municipal job fair Nov 15.", DatePosted = DateTime.Now, Category = "Employment" },
                new() { Id = 12, Title = "COVID-19 Booster Clinics", Message = "Free boosters at local health centers.", DatePosted = DateTime.Now, Category = "Health" },
                new() { Id = 13, Title = "Recycling Program Update", Message = "Glass recycling resumes Nov 10.", DatePosted = DateTime.Now, Category = "Environment" },
                new() { Id = 14, Title = "Public Transport Schedule", Message = "Revised bus and train timetables from Dec 1.", DatePosted = DateTime.Now, Category = "Transport" },
                new() { Id = 15, Title = "Flood Awareness Alert", Message = "Prepare for heavy rains in Durban.", DatePosted = DateTime.Now, Category = "Environment" },
                new() { Id = 16, Title = "School Safety Program", Message = "New safety measures implemented in schools.", DatePosted = DateTime.Now, Category = "Safety" },
                new() { Id = 17, Title = "Library Event Series", Message = "Storytelling sessions for children.", DatePosted = DateTime.Now, Category = "Education" },
                new() { Id = 18, Title = "Local Art Competition", Message = "Enter your artwork by Nov 30.", DatePosted = DateTime.Now, Category = "Culture" },
                new() { Id = 19, Title = "Sports Facility Upgrade", Message = "Renovation of community sports centers.", DatePosted = DateTime.Now, Category = "Sports" },
                new() { Id = 20, Title = "Municipal Budget Feedback", Message = "Provide feedback on proposed budget.", DatePosted = DateTime.Now, Category = "Government" }
               
            };

            // Add announcements using helper method
            foreach (var ann in announcements)
            {
                AddAnnouncement(ann);
            }
        }

        // Add Announcement Helper
        // Adds announcement to dictionary and category set
        public static void AddAnnouncement(Announcements announcement)
        {
            if (announcement == null || string.IsNullOrEmpty(announcement.Category))
                return; 

            bool exists = false;

            // Check if category already exists
            foreach (var key in AnnouncementsByCategory.Keys)
            {
                if (key.Equals(announcement.Category, StringComparison.OrdinalIgnoreCase))
                {
                    AnnouncementsByCategory[key].Add(announcement);
                    exists = true;
                    break;
                }
            }

            // If category doesn't exist, create new entry
            if (!exists)
            {
                AnnouncementsByCategory.Add(announcement.Category, new List<Announcements> { announcement });
            }

            // Add category to unique category set
            if (!AnnouncementCategories.Contains(announcement.Category))
                AnnouncementCategories.Add(announcement.Category);
        }

        // Retrieve announcements by category
        public static List<Announcements> GetAnnouncementsByCategory(string category)
        {
            foreach (var key in AnnouncementsByCategory.Keys)
            {
                if (key.Equals(category, StringComparison.OrdinalIgnoreCase))
                    return AnnouncementsByCategory[key]; 
            }
            return new List<Announcements>(); 
        }

        // Retrieve all announcements
        public static List<Announcements> GetAllAnnouncements()
        {
            var all = new List<Announcements>();
            foreach (var key in AnnouncementsByCategory.Keys)
            {
                all.AddRange(AnnouncementsByCategory[key]); 
            }
            return all;
        }

        // Log user search term
        // Updates search count or adds new entry
        public static void LogUserSearch(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return; 

            bool exists = false;

            foreach (var key in UserSearchPreferences.Keys)
            {
                if (key.Equals(query, StringComparison.OrdinalIgnoreCase))
                {
                    UserSearchPreferences[key]++; 
                    exists = true;
                    break;
                }
            }

            if (!exists)
                UserSearchPreferences.Add(query, 1);
        }

        // Log user interest by category
        // Updates category count for recommendations
        public static void LogUserCategory(string? category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return; 

            bool exists = false;

            foreach (var key in UserSearchPreferences.Keys)
            {
                if (key.Equals(category, StringComparison.OrdinalIgnoreCase))
                {
                    UserSearchPreferences[key]++;
                    exists = true;
                    break;
                }
            }

            if (!exists)
                UserSearchPreferences.Add(category, 1);
        }

        // Event Recommendations
        // Returns list of events based on top user category
        public static List<Events> GetRecommendedEvents(int maxItems = 5)
        {
            var recommended = new List<Events>();

            if (UserSearchPreferences.Count == 0)
                return recommended; 
            // Determine top category by highest count
            string? topCategory = null;
            int highestValue = int.MinValue;

            foreach (var key in UserSearchPreferences.Keys)
            {
                int value = UserSearchPreferences[key];
                if (value > highestValue)
                {
                    highestValue = value;
                    topCategory = key;
                }
            }

            if (string.IsNullOrEmpty(topCategory))
                return recommended;

            // Collect events matching top category
            foreach (var e in EventsQueue.UnorderedItems)
            {
                if (!string.IsNullOrEmpty(e.Category) &&
                    e.Category.Equals(topCategory, StringComparison.OrdinalIgnoreCase))
                {
                    recommended.Add(e);
                    if (recommended.Count >= maxItems) break; 
                }
            }

            return recommended;
        }
    }
}
