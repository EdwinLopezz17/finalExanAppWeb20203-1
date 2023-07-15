using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace si730ebu20201b051.Domain.Request;

public class ProductRequest
{
    [Required]
    public string brand { get; set; }
    
    [Required]
    public string model { get; set; }
    
    [Required]
    public string serialNumber { get; set; }
    
    [Required]
    [RegularExpression("^(OPERATIONAL|UNOPERATIONAL)$", ErrorMessage = "statusDescription must be either 'OPERATIONAL' or 'UNOPERATIONAL'.")]
    public string statusDescription { get; set; }
}