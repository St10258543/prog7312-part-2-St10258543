public class MongoSettings
{
    // Connection string for MongoDB 
    public string ConnectionString { get; set; } = null!;

    // Name of the MongoDB database to use
    public string DatabaseName { get; set; } = null!;

    // Name of the collection that stores issues
    public string ReportsCollectionName { get; set; } = "Issues";
}
