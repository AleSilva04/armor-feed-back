using System.Net.Mime;
using ArmorFeedApi.Payments.Domain.Model;
using ArmorFeedApi.Payments.Domain.Services;
using ArmorFeedApi.Payments.Resources;
using ArmorFeedApi.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArmorFeedApi.Payments.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Create and read Payments")]
[Produces(MediaTypeNames.Application.Json)]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IMapper _mapper;

    public PaymentsController(IPaymentService paymentService, IMapper mapper)
    {
        _paymentService = paymentService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Payment detail given Shipment",
        Description = "Get existing Payment associated with the specified Shipment",
        OperationId = "GetPayments",
        Tags = new []{"Payments"}
    )]
    [ProducesResponseType(typeof(IEnumerable<PaymentResource>), 200)]
    [ProducesDefaultResponseType()]
    public async Task<IEnumerable<PaymentResource>> GetAllAsync()
    {
        var payments = await _paymentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);
        return resources;
    }
    [HttpGet("shipment/{id}")]
    public async Task<PaymentResource> GetAllByShipmentIdAsync(int id)
    {
        var payments = await _paymentService.ListByShipmentIdAsync(id);
        var resources = _mapper.Map<Payment, PaymentResource>(payments);
        return resources;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Post Payment detail given Shipment",
        Description = "Post existing Payment associated with the specified Shipment",
        OperationId = "SetPayments",
        Tags = new []{"Payments"}
    )]
    [ProducesResponseType(typeof(PaymentResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SavePaymentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var payment = _mapper.Map<SavePaymentResource, Payment>(resource);

        var result = await _paymentService.SaveAsync(payment);

        if (!result.Success)
            return BadRequest(result.Message);

        var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

        return Ok(paymentResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Put Payment",
        Description = "Put existing Payment associated with the specified Shipment",
        OperationId = "SetPayments",
        Tags = new []{"Payments"}
    )]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var payment = _mapper.Map<SavePaymentResource, Payment>(resource);

        var result = await _paymentService.UpdateAsync(id, payment);

        if (!result.Success)
            return BadRequest(result.Message);

        var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

        return Ok(paymentResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete Payment",
        Description = "Delete exiting payment in database",
        OperationId = "SetPayments",
        Tags = new []{"Payments"}
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _paymentService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

        return Ok(paymentResource);

    }
}