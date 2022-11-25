using ArmorFeedApi.Comments.Domain.Models;
using ArmorFeedApi.Comments.Domain.Services.Communication;

namespace ArmorFeedApi.Comments.Domain.Services;

public interface ICommentService
{
    Task<IEnumerable<Comment>> ListAsync();

    Task<IEnumerable<Comment>> ListByCustomerAsync(int customerId);
    Task<IEnumerable<Comment>> ListByShipmentAsync(int shipmentId);

    Task<Comment> FindByIdAsync(int id);
    Task<CommentResponse> SaveAsync(Comment comment);
    Task<CommentResponse> UpdateAsync(int id, Comment comment);
    Task<CommentResponse> DeleteAsync(int id);
}