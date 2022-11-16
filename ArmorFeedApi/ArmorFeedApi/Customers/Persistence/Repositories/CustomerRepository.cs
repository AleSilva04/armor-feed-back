using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Customers.Domain.Repositories;
using ArmorFeedApi.Shared.Persistence.Contexts;
using ArmorFeedApi.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArmorFeedApi.Customers.Persistence.Repositories;
public class CustomerRepository: BaseRepository, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Customer>> ListAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task AddAsync(Customer user)
    {
        await _context.Customers.AddAsync(user);
    }

    public async Task<Customer> FindByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer> FindByEmailAsync(string email)
    {
        return await _context.Customers.SingleOrDefaultAsync(x => x.Email == email);
    }

    public bool ExitsByEmail(string email)
    {
        return _context.Customers.Any(x => x.Email == email);
    }

    public Customer FindById(int id)
    {
        return _context.Customers.Find(id);
    }

    public void Update(Customer user)
    {
        _context.Customers.Update(user);
    }

    public void Remove(Customer user)
    {
        _context.Customers.Remove(user);
    }
}