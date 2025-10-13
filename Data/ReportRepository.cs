using MunicipalityApp.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MunicipalityApp.Data
{
    public class ReportRepository : IReportRepository
    {
        private readonly IMongoCollection<Issues> _issuesCollection;

        public ReportRepository(IOptions<MongoSettings> mongoSettings, IMongoClient client)
        {
            var settings = mongoSettings.Value;

            // Gets the MongoDB database and collection
            var database = client.GetDatabase(settings.DatabaseName);
            _issuesCollection = database.GetCollection<Issues>(settings.ReportsCollectionName);
        }

        // Creates a new report
        public async Task CreateAsync(Issues issue)
        {
            await _issuesCollection.InsertOneAsync(issue);
        }

        // Gets all reports
        public async Task<List<Issues>> GetAllAsync()
        {
            return await _issuesCollection.Find(_ => true).ToListAsync();
        }

        // Gets a report by Id
        public async Task<Issues?> GetByIdAsync(string id)
        {
            return await _issuesCollection.Find(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}
