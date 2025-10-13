using MunicipalityApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MunicipalityApp.Data
{
    // Define an interface for the report repository
    public interface IReportRepository
    {
        Task CreateAsync(Issues issue); // Creates a new issue record in the repository
        Task<List<Issues>> GetAllAsync(); // Retrieves all issues from the repository
        Task<Issues?> GetByIdAsync(string id); //Retrieves a single issue by its ID
    }
}
