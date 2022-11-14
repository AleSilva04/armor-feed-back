using ArmorFeedApi.Comments.Domain.Models;
using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Payments.Domain.Model;

namespace ArmorFeedApi.Shipments.Domain.Models;

public class Shipment
{
    public int Id { get; set; }
    public string PickUpDate { get; set; }
    public string DeliveryDate { get; set; }
    public string Status { get; set; }
    public string Origin { get; set; }
    public string OriginTypeAddress { get; set; }
    public string OriginAddress { get; set; }
    public string OriginUrbanization { get; set; }
    public string OriginReference { get; set; }
    public string Destiny { get; set; }
    public string DestinyTypeAddress { get; set; }
    public string DestinyAddress { get; set; }
    public string DestinyUrbanization { get; set; }
    public string DestinyReference { get; set; }
    
    public int EnterpriseId { get; set; }
    public Enterprise Enterprise { get; set; }
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public IList<Comment> Comments { get; set; } = new List<Comment>();
}