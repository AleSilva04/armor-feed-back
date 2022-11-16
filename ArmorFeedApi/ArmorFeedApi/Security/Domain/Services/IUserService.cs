using ArmorFeedApi.Security.Domain.Models;
using ArmorFeedApi.Security.Domain.Services.Communication;

namespace ArmorFeedApi.Security.Domain.Services;

public interface IUserService<T>
{
    Task<IEnumerable<T>> ListAsync();
    Task<T> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}