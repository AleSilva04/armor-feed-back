using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Customers.Domain.Services.Communication;
using ArmorFeedApi.Security.Domain.Models;
using ArmorFeedApi.Security.Domain.Services.Communication;
using AutoMapper;


namespace ArmorFeedApi.Customers.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterCustomerRequest, Customer>();
        CreateMap<UpdateCustomerRequest, Customer>()
            .ForAllMembers(options=>options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }
                ));
        
    }
}