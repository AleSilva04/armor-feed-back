using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Customers.Domain.Services.Communication;
using ArmorFeedApi.Customers.Resource;
using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Services.Communication;
using ArmorFeedApi.Enterprises.Resources;
using ArmorFeedApi.Security.Domain.Models;
using ArmorFeedApi.Security.Domain.Services.Communication;
using ArmorFeedApi.Security.Resources;
using AutoMapper;

namespace ArmorFeedApi.Enterprises.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Enterprise, AuthenticateEnterpriseResponse>();
        CreateMap<Enterprise, EnterpriseResource>();
    }
}