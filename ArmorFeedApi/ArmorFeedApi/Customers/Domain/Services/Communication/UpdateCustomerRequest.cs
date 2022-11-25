using ArmorFeedApi.Security.Domain.Services.Communication;

namespace ArmorFeedApi.Customers.Domain.Services.Communication;

public class UpdateCustomerRequest : UpdateRequest
{
    public string LastName { get; set; }
    public int SubscriptionPlan { get; set; }
}