using ArmorFeedApi.Comments.Domain.Models;
using ArmorFeedApi.Shared.Domain.Services.Communication;

namespace ArmorFeedApi.Comments.Domain.Services.Communication;

public class CommentResponse:BaseResponse<Comment>
{
    public CommentResponse(Comment resource) : base(resource)
    {
    }
    public CommentResponse(string message) : base(message)
    {
    }
}