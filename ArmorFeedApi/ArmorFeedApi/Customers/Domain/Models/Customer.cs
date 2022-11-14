using ArmorFeedApi.Security.Domain.Models;

namespace ArmorFeedApi.Customers.Domain.Models;

public class Customer : User
{
    
    public string LastName { get; set; }
    public int SubscriptionPlan { get; set; }
}