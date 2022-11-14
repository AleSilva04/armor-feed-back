using ArmorFeedApi.Security.Domain.Services.Communication;

namespace ArmorFeedApi.Customers.Domain.Services.Communication;

public class AuthenticateCustomerResponse: AuthenticateResponse
{
    public string LastName { get; set; }
    public int SubscriptionPlan { get; set; }
}