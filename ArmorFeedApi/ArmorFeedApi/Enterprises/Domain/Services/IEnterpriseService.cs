using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Services.Communication;
using ArmorFeedApi.Security.Domain.Services;
using ArmorFeedApi.Security.Domain.Services.Communication;

namespace ArmorFeedApi.Enterprises.Domain.Services;

public interface IEnterpriseService: IUserService<Enterprise>
{
    Task<AuthenticateEnterpriseResponse> Authenticate(AuthenticateRequest request);
    Task RegisterAsync(RegisterEnterpriseRequest request);
    Task UpdateAsync(int id, UpdateEnterpriseRequest request);
}