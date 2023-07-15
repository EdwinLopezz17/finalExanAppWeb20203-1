namespace si730ebu20201b051.Infraestructure.Models;

public class MaintenanceActivity
{
    public int id { get; set; }
    public string productSerialNumber { get; set; }
    public string summary { get; set; }
    public string description { get; set; }
    public int activityResult { get; set; }
}