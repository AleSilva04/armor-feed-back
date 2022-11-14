using System.ComponentModel.DataAnnotations;
using ArmorFeedApi.Customers.Resource;
using ArmorFeedApi.Shipments.Resources;

namespace ArmorFeedApi.Comments.Resources;

public class SaveCommentResource
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set;}
    [Required]
    public string Content { get; set; }
    [Required]
    public int  CustomerId { get; set; }
    [Required]
    public int ShipmentId { get; set; }
}