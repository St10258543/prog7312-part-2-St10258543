namespace MunicipalityApp
{
    public class Announcements
    {
        public int Id {get; set;}
        public string Title {get; set; } = string.Empty;
        public string Message {get; set;} = string.Empty;
        public DateTime DatePosted {get; set;}
        public string Category {get; set;} = string.Empty;
    }
}