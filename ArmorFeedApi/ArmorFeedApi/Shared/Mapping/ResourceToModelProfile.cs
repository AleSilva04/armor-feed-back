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

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePaymentResource, Payment>();
        CreateMap<SaveVehicleResource, Vehicle>();
        CreateMap<SaveCustomerResource,Customer>();
        CreateMap<SaveShipmentResource, Shipment>();
        CreateMap<SaveCommentResource, Comment>();
    }
}