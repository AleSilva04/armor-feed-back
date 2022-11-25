using ArmorFeedApi.Shipments.Domain.Models;

namespace ArmorFeedApi.Payments.Domain.Model;

public class Payment
{
    public int Id { get; set; }
    public float Amount { get; set; }
    public string Currency { get; set; }
    public string PaymentDate { get; set; }
    public int ShipmentId { get; set; }
    public Shipment Shipment { get; set; }
}