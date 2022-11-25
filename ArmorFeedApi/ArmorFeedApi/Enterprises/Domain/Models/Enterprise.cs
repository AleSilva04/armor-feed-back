using ArmorFeedApi.Security.Domain.Models;
using ArmorFeedApi.Vehicles.Domain.Models;

namespace ArmorFeedApi.Enterprises.Domain.Models;

public class Enterprise : User
{
    public float PriceBase { get; set; }
    public float FactorWeight { get; set; }
    public int ShippingTime { get; set; }
    public float Score { get; set; }
    
    public IList<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}