using System.ComponentModel.DataAnnotations;

namespace ArmorFeedApi.Customers.Resource;

public class SaveCustomerResource
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Ruc { get; set; }
    [Required]
    public int SubscriptionPlan { get; set; }
}