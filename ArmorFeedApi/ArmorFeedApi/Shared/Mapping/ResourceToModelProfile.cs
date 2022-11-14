using ArmorFeedApi.Payments.Domain.Model;
using ArmorFeedApi.Payments.Resources;
using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Enterprises.Resources;
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
        CreateMap<SaveEnterpriseResource, Enterprise>();
        CreateMap<SaveVehicleResource, Vehicle>();
    }
}