using System.Net.Mime;
using ArmorFeedApi.Shared.Extensions;
using ArmorFeedApi.Shipments.Domain.Models;
using ArmorFeedApi.Shipments.Domain.Services;
using ArmorFeedApi.Shipments.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArmorFeedApi.Shipments.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Create, Read And Update Shipments")]
[Produces(MediaTypeNames.Application.Json)]
public class ShipmentsController : ControllerBase
{
    private readonly IShipmentService _shipmentService;
    private readonly IMapper _mapper;

    public ShipmentsController(IShipmentService shipmentService, IMapper mapper)
    {
        _shipmentService = shipmentService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Shipments",
        Description = "Get Existing Shipments In DataBase",
        OperationId = "GetShipments",
        Tags = new []{"Shipments"}
    )]
    public async Task<IEnumerable<ShipmentResource>> GetAllAsync()
    {
        var shipments = await _shipmentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Shipment>, IEnumerable<ShipmentResource>>(shipments);
        return resources;
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Shipments By Id",
        Description = "Get Existing Shipments In DataBase By Id",
        OperationId = "GetShipmentById",
        Tags = new []{"Shipments"}
    )]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var shipment = await _shipmentService.GetByIdAsync(id);
        var resource = _mapper.Map<Shipment, ShipmentResource>(shipment);
        return Ok(resource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Save Shipments In DataBase",
        Description = "Save Shipment Record In DataBase",
        OperationId = "PostShipment",
        Tags = new []{"Shipments"}
    )]
    public async Task<IActionResult> PostAsync([FromBody] SaveShipmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var shipment = _mapper.Map<SaveShipmentResource, Shipment>(resource);

        var result = await _shipmentService.SaveAsync(shipment);

        if (!result.Success)
            return BadRequest(result.Message);

        var paymentResource = _mapper.Map<Shipment, ShipmentResource>(result.Resource);

        return Ok(paymentResource);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update Shipments In DataBase",
        Description = "Update Shipment Record In DataBase",
        OperationId = "PutShipment",
        Tags = new []{"Shipments"}
    )]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveShipmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
            
        var shipment = _mapper.Map<SaveShipmentResource, Shipment>(resource);

        var result = await _shipmentService.UpdateAsync(id, shipment);
            
        if (!result.Success)
            return BadRequest(result.Message);

        var shipmentResource = _mapper.Map<Shipment, ShipmentResource>(result.Resource);

        return Ok(shipmentResource);
    }
}