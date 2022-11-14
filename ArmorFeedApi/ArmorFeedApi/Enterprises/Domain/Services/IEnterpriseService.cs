using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Services.Communication;

namespace ArmorFeedApi.Enterprises.Domain.Services;

public interface IEnterpriseService
{
    Task<IEnumerable<Enterprise>> ListAsync();
    Task<EnterpriseResponse> SaveAsync(Enterprise enterprise);
    Task<EnterpriseResponse> UpdateAsync(int id, Enterprise enterprise);
    Task<EnterpriseResponse> DeleteAsync(int id);
}