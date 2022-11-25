using ArmorFeedApi.Customers.Resource;
using ArmorFeedApi.Shipments.Resources;

namespace ArmorFeedApi.Comments.Resources;

public class CommentResource
{
    public int Id { get; set; }
    public string Title { get; set;}
    public string Content { get; set; }
    public CustomerResource Customer;
    public ShipmentResource Shipment;
}