

namespace ArmorFeedApi.Enterprises.Resources;

public class EnterpriseResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Ruc { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public float PriceBase { get; set; }
    public float FactorWeight { get; set; }
    public int ShippingTime { get; set; }
    public float Score { get; set; }
    public string Photo { get; set; }
}