using ArmorFeedApi.Security.Domain.Services.Communication;

namespace ArmorFeedApi.Enterprises.Domain.Services.Communication;

public class UpdateEnterpriseRequest : UpdateRequest
{
    public float PriceBase { get; set; }
    public float FactorWeight { get; set; }
    public int ShippingTime { get; set; }
    public float Score { get; set; }
}