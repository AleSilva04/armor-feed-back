

using ArmorFeedApi.Enterprises.Domain.Models;

namespace ArmorFeedApi.Enterprises.Domain.Repositories;

public interface IEnterpriseRepository
{
    Task<IEnumerable<Enterprise>> ListAsync();
    Task AddAsync(Enterprise enterprise);
    Task<Enterprise> FindByIdAsync(int id);
    void Update(Enterprise enterprise);
    void Remove(Enterprise enterprise);
}