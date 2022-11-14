
using ArmorFeedApi.Enterprises.Resources;

namespace ArmorFeedApi.Vehicles.Resources;

public class VehicleResource
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string LicensePlate  { get; set; }
    public int Year { get; set; }
    public string Model { get; set; }
    public string MaintenanceDate { get; set; }
    public string VehicleType { get; set; }
    public EnterpriseResource Enterprise;

}