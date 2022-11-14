
using System.ComponentModel.DataAnnotations;

namespace ArmorFeedApi.Vehicles.Resources;

public class SaveVehicleResource
{
    [Required]
    public string Brand { get; set; }
    [Required]
    public string LicensePlate { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public string MaintenanceDate { get; set; }
    [Required]
    public string VehicleType { get; set; }
    [Required]
    public int EnterpriseId { get; set; }
    
}