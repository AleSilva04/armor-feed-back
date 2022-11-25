using System.ComponentModel.DataAnnotations;
using ArmorFeedApi.Security.Domain.Services.Communication;

namespace ArmorFeedApi.Enterprises.Domain.Services.Communication;

public class RegisterEnterpriseRequest: RegisterRequest
{
    [Required] public float PriceBase { get; set; }
    [Required] public float FactorWeight { get; set; }
    [Required] public int ShippingTime { get; set; }
    [Required] public float Score { get; set; }
}