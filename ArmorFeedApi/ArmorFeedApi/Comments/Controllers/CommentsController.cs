using System.Net.Mime;
using ArmorFeedApi.Comments.Domain.Models;
using ArmorFeedApi.Comments.Domain.Services;
using ArmorFeedApi.Comments.Resources;
using ArmorFeedApi.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArmorFeedApi.Comments.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, Read, Update and Delete Comments")]
public class CommentsController:ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;
    public CommentsController(ICommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Comments",
        Description = "Get All Comment",
        OperationId = "GetComments",
        Tags = new []{"Comments"}
    )]
    public async Task<IEnumerable<CommentResource>> GetAllAsync()
    {
        var comments = await _commentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);

        return resources;
    }
    [HttpPost]
    [SwaggerOperation(
        Summary = "Post Comment",
        Description = "Save Comment In Database",
        OperationId = "PostComment",
        Tags = new []{"Comments"}
    )]
    public async Task<IActionResult> PostAsync([FromBody] SaveCommentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var comment = _mapper.Map<SaveCommentResource, Comment>(resource);

        var result = await _commentService.SaveAsync(comment);

        if (!result.Success)
            return BadRequest(result.Message);

        var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);

        return Ok(commentResource);
    }
    
}