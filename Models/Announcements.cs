namespace MunicipalityApp
{
    public class Announcements
    {
        // Unique identifier for the announcement.
        public int Id { get; set; }

        // The title or headline of the announcement.
        public string Title { get; set; } = string.Empty;

        // The full message or body content of the announcement.
        public string Message { get; set; } = string.Empty;

        // The date and time when the announcement was posted.
        public DateTime DatePosted { get; set; }

        // The category or type of announcement (e.g., "Public Notice", "Event", "Update").
        public string Category { get; set; } = string.Empty;
    }
}
