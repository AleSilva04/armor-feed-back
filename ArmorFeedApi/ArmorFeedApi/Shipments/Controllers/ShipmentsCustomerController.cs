using System.Net.Mime;
using ArmorFeedApi.Shipments.Domain.Models;
using ArmorFeedApi.Shipments.Domain.Services;
using ArmorFeedApi.Shipments.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace ArmorFeedApi.Shipments.Controllers;
[ApiController]
[Route("/api/v1/customers/{customerId}/shipments")]
public class ShipmentsCustomerController
{
    private readonly IShipmentService _shipmentService;
    private readonly IMapper _mapper;

    public ShipmentsCustomerController(IShipmentService shipmentService, IMapper mapper)
    {
        _shipmentService = shipmentService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Shipments",
        Description = "Get All Shipments by Enterprise Id",
    OperationId = "GetShipments ",
        Tags = new[] { "Shipments" }
    )]
    public async Task<IEnumerable<ShipmentResource>> GetAllByEnterpriseId(int customerId)
    {
        var shipments = await _shipmentService.ListByCustomerId(customerId);
        var resources = _mapper.Map<IEnumerable<Shipment>, IEnumerable<ShipmentResource>>(shipments);
        return resources;
    }
}