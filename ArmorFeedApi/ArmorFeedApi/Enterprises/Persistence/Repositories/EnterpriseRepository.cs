using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Repositories;
using ArmorFeedApi.Shared.Persistence.Contexts;
using ArmorFeedApi.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArmorFeedApi.Enterprises.Persistence.Repositories;

public class EnterpriseRepository: BaseRepository, IEnterpriseRepository
{
    public EnterpriseRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Enterprise>> ListAsync()
    {
        return await _context.Enterprises.ToListAsync();
    }
    public async Task AddAsync(Enterprise enterprise)
    {
        await _context.Enterprises.AddAsync(enterprise);
    }

    public async Task<Enterprise> FindByIdAsync(int id)
    {
        return await _context.Enterprises.FindAsync(id);
    }

    public async Task<Enterprise> FindByEmailAsync(string email)
    {
        return await _context.Enterprises.SingleOrDefaultAsync(x => x.Email == email);
    }

    public bool ExitsByEmail(string email)
    {
        return _context.Enterprises.Any(x => x.Email == email);

    }

    public Enterprise FindById(int id)
    {
        return _context.Enterprises.Find(id);
    }

    public void Update(Enterprise enterprise)
    {
        _context.Enterprises.Update(enterprise);
    }

    public void Remove(Enterprise enterprise)
    {
        _context.Enterprises.Remove(enterprise);
    }
}