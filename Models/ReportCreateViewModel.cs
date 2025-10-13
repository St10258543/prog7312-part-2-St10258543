using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class ReportCreateViewModel
{
    // Location where the issue occurred
    [Required]
    public string Location { get; set; } = null!;

    // Category/type of issue
    [Required]
    public string Category { get; set; } = null!;

    // Detailed description of the issue
    [Required]
    public string Description { get; set; } = null!;

    // List of uploaded media files associated with the issue
    public List<IFormFile>? Media { get; set; }
}
