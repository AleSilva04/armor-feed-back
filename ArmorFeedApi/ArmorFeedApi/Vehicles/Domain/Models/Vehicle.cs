

using ArmorFeedApi.Enterprises.Domain.Models;

namespace ArmorFeedApi.Vehicles.Domain.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string LicensePlate  { get; set; }
    public int Year { get; set; }
    public string Model { get; set; }
    public string MaintenanceDate { get; set; }
    public string VehicleType { get; set; }
    
    //Relationships
    public int EnterpriseId { get; set; }
    public Enterprise Enterprise { get; set; }

}