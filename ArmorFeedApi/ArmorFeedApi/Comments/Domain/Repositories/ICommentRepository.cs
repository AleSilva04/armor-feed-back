using ArmorFeedApi.Comments.Domain.Models;

namespace ArmorFeedApi.Comments.Domain.Repositories;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> ListAsync();
    Task<IEnumerable<Comment>> FindByCustomerId(int id);
    Task<IEnumerable<Comment>> FindByShipmentId(int id);
    Task AddAsync(Comment comment);
    Task<Comment> FindByIdAsync(int id);
    void Update(Comment comment);
    void Remove(Comment comment);
}