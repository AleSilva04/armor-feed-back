using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Shipments.Domain.Models;

namespace ArmorFeedApi.Comments.Domain.Models;

public class Comment
{
    public int Id { get; set; }
    public string Title { get; set;}
    public string Content { get; set; }
    //Relationships
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int ShipmentId { get; set; }
    public Shipment Shipment { get; set; }
    
    
}