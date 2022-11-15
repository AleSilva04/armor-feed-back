using ArmorFeedApi.Security.Domain.Models;
using ArmorFeedApi.Security.Domain.Services.Communication;
using ArmorFeedApi.Security.Resources;
using AutoMapper;

namespace ArmorFeedApi.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}