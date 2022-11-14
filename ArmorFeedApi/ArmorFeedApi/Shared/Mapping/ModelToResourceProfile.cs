
using ArmorFeedApi.Comments.Domain.Models;
using ArmorFeedApi.Comments.Resources;
using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Customers.Resource;
using ArmorFeedApi.Payments.Domain.Model;
using ArmorFeedApi.Payments.Resources;
using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Enterprises.Resources;
using ArmorFeedApi.Shipments.Domain.Models;
using ArmorFeedApi.Shipments.Resources;
using ArmorFeedApi.Vehicles.Domain.Models;
using ArmorFeedApi.Vehicles.Resources;
using AutoMapper;
using Enterprise = ArmorFeedApi.Enterprises.Domain.Models.Enterprise;

namespace ArmorFeedApi.Shared.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Payment, PaymentResource>();
        CreateMap<Enterprise,EnterpriseResource>();
        CreateMap<Vehicle, VehicleResource>();
        CreateMap<Customer,CustomerResource>();
        CreateMap<Shipment, ShipmentResource>();
        CreateMap<Comment, CommentResource>();
    }
}