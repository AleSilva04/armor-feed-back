using ArmorFeedApi.Security.Domain.Models;

namespace ArmorFeedApi.Security.Domain.Respositories;

public interface IUserRepository<T>
{
    Task<IEnumerable<T>> ListAsync();
    Task AddAsync(T user);
    Task<T> FindByIdAsync(int id);
    Task<T> FindByEmailAsync(string email);
    bool ExitsByEmail(string email);
    T FindById(int id);
    void Update(T user);
    void Remove(T user);
}