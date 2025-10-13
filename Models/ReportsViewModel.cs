using MunicipalityApp.Models;
using System.Collections.Generic;

namespace MunicipalityApp.ViewModels
{
    public class ReportsViewModel
    {
        // List of issues to display in the view
        public List<Issues> Reports { get; set; } = new List<Issues>();
    }
}
