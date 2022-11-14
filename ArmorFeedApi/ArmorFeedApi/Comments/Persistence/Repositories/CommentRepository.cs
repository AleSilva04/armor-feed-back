using ArmorFeedApi.Comments.Domain.Models;
using ArmorFeedApi.Comments.Domain.Repositories;
using ArmorFeedApi.Shared.Persistence.Contexts;
using ArmorFeedApi.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArmorFeedApi.Comments.Persistence.Repositories;

public class CommentRepository: BaseRepository,ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Comment>> ListAsync()
    {
        return await _context.Comments.ToListAsync();
    }
    
    public async Task<IEnumerable<Comment>> FindByCustomerId(int id)
    {
        return await _context.Comments
            .Where(p => p.CustomerId == id)
            .Include(p => p.Customer)
            .ToListAsync();
    }
    public async Task<IEnumerable<Comment>> FindByShipmentId(int id)
    {
        return await _context.Comments
            .Where(p => p.ShipmentId == id)
            .Include(p => p.Shipment)
            .ToListAsync();
    }


    public async Task AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
    }

    public async Task<Comment> FindByIdAsync(int id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public void Update(Comment comment)
    {
        _context.Comments.Update(comment);
    }

    public void Remove(Comment comment)
    {
        _context.Comments.Remove(comment);
    }

}