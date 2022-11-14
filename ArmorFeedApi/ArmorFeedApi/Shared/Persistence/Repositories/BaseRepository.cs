using ArmorFeedApi.Shared.Persistence.Contexts;

namespace ArmorFeedApi.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}