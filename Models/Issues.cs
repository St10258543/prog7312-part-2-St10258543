using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MunicipalityApp.Models
{
    public class Issues
    {
        // MongoDB ObjectId, stored as a string
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        // Location of where the issue occurred
        public string Location { get; set; } = null!;

        // Category/type of issue
        public string Category { get; set; } = null!;

        // Detailed description of the issue
        public string Description { get; set; } = null!;

        // File name of any uploaded media
        public string? MediaFileName { get; set; }

        // Current status of the issue, default is "Pending"
        public string Status { get; set; } = "Pending";

        // Date and time when the issue was submitted
        public DateTime DateSubmitted { get; set; } = DateTime.UtcNow;
    }
}
