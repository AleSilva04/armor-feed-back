using ArmorFeedApi.Comments.Domain.Models;
using ArmorFeedApi.Comments.Domain.Services;
using ArmorFeedApi.Comments.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArmorFeedApi.Comments.Controllers;

[ApiController]
[Route("/api/v1/shipment/{shipmentId}/comments")] 
public class ShipmentCommentController:ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;

    public ShipmentCommentController(ICommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Comments",
        Description = "Get All Comments by Shipment Id",
        OperationId = "GetComments",
        Tags = new []{"Comments"}
    )]
    public async Task<IEnumerable<CommentResource>> GetAllByShipmentId(int shipmentId)
    {
        var comments = await _commentService.ListByShipmentAsync(shipmentId);
        var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);
        return resources;
    }
}