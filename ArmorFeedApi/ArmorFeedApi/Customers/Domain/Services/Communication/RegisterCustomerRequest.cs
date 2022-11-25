using System.ComponentModel.DataAnnotations;
using ArmorFeedApi.Security.Domain.Services.Communication;

namespace ArmorFeedApi.Customers.Domain.Services.Communication;

public class RegisterCustomerRequest : RegisterRequest
{
    [Required] public string LastName { get; set; }
    [Required] public int SubscriptionPlan { get; set; }
}