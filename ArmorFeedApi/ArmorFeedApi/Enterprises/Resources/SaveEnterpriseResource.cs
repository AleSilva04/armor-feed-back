

using System.ComponentModel.DataAnnotations;

namespace ArmorFeedApi.Enterprises.Resources;

public class SaveEnterpriseResource
{   
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Ruc { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public float PriceBase { get; set; }
    [Required]
    public float FactorWeight { get; set; }
    [Required]
    public int ShippingTime { get; set; }
    [Required]
    public float Score { get; set; }
    [Required]
    public string Photo { get; set; }
}