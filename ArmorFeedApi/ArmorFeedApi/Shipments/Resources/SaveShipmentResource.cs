using System.ComponentModel.DataAnnotations;

namespace ArmorFeedApi.Shipments.Resources;

public class SaveShipmentResource
{
    [Required]
    [MaxLength(50)]
    public string Origin { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string OriginTypeAddress { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string OriginAddress { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string OriginUrbanization { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string OriginReference { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Destiny { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string DestinyTypeAddress { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string DestinyAddress { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string DestinyUrbanization { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string DestinyReference { get; set; }

    [Required]
    public string PickUpDate { get; set; }
    
    [Required]
    public string DeliveryDate { get; set; }
    
    [Required]
    public int Status { get; set; }
    
    [Required]
    public int EnterpriseId { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
}