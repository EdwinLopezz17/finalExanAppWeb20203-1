using System.ComponentModel.DataAnnotations;

namespace si730ebu20201b051.Domain.Request;

public class MaintenanceActivityRequest
{
    [Required]
    public string productSerialNumber { get; set; }
    
    [Required]
    public string summary { get; set; }
    
    
    public string description { get; set; }
    
    [Required]
    [Range(0, 1, ErrorMessage = "activityResult must be either 0 or 1.")]
    public int activityResult { get; set; }
}