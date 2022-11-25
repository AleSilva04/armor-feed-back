namespace ArmorFeedApi.Profile.Domain.Models;

public class Customer : User
{
    public string CustomerDescription { get; set; }
    public int SubscriptionPlan { get; set; }
}