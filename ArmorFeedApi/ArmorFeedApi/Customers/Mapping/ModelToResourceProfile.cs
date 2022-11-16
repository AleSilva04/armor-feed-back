using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Customers.Domain.Services.Communication;
using ArmorFeedApi.Customers.Resource;
using ArmorFeedApi.Security.Domain.Models;
using ArmorFeedApi.Security.Domain.Services.Communication;
using ArmorFeedApi.Security.Resources;
using AutoMapper;

namespace ArmorFeedApi.Customers.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Customer, AuthenticateCustomerResponse>();
        CreateMap<Customer, CustomerResource>();
    }
}