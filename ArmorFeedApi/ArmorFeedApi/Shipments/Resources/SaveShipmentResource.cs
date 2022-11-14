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
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime PickUpDate { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DeliveryDate { get; set; }
    
    [Required]
    public int Status { get; set; }
    
    [Required]
    public int EnterpriseId { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
}