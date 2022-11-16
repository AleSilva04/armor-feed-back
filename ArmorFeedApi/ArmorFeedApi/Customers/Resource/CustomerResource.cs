using ArmorFeedApi.Security.Resources;

namespace ArmorFeedApi.Customers.Resource;

public class CustomerResource : UserResource
{
    public string LastName { get; set; }
    public int SubscriptionPlan { get; set; }
}