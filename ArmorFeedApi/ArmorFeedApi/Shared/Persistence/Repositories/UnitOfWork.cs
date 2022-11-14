using ArmorFeedApi.Shared.Domain.Repositories;
using ArmorFeedApi.Shared.Persistence.Contexts;

namespace ArmorFeedApi.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}