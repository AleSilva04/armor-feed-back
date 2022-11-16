
using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Customers.Domain.Services.Communication;
using ArmorFeedApi.Security.Domain.Services;
using ArmorFeedApi.Security.Domain.Services.Communication;

namespace ArmorFeedApi.Customers.Domain.Services;

public interface ICustomerService: IUserService<Customer>
{
    Task<AuthenticateCustomerResponse> Authenticate(AuthenticateRequest request);
    Task RegisterAsync(RegisterCustomerRequest request);
    Task UpdateAsync(int id, UpdateCustomerRequest request);
}