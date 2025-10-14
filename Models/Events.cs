namespace MunicipalityApp.Models
{
    public class Events
    {
        // Unique identifier for the event.
        public int Id { get; set; }

        // The title or name of the event.
        public string Title { get; set; } = string.Empty;

        // A detailed description of the event, including important information.
        public string Description { get; set; } = string.Empty;

        // The date and time when the event will take place.
        public DateTime Date { get; set; }

        // The category of the event (e.g., "Community", "Cultural", "Maintenance", etc.).
        public string Category { get; set; } = string.Empty;
    }
}
