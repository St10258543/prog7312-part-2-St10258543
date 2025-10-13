namespace MunicipalityApp.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Title{ get; set; } = string.Empty;
        public string Description { get; set;} = string.Empty;
        public DateTime Date {get; set; }
        public string Category {get; set; } = string.Empty;

    }
}