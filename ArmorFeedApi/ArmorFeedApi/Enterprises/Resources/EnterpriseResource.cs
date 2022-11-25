

using ArmorFeedApi.Security.Resources;

namespace ArmorFeedApi.Enterprises.Resources;

public class EnterpriseResource : UserResource
{
    public float PriceBase { get; set; }
    public float FactorWeight { get; set; }
    public int ShippingTime { get; set; }
    public float Score { get; set; }
}