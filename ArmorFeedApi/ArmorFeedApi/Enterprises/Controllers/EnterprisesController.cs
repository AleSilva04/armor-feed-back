using System.Net.Mime;
using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Services;
using ArmorFeedApi.Enterprises.Resources;
using ArmorFeedApi.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArmorFeedApi.Enterprises.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, Read, Update and Delete Enterprises")]
public class EnterprisesController: ControllerBase
{
    private readonly IEnterpriseService _enterpriseService;
    private readonly IMapper _mapper;

    public EnterprisesController(IEnterpriseService enterpriseService, IMapper mapper)
    {
        _enterpriseService = enterpriseService;
        _mapper = mapper;
    }
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Enterprise",
        Description = "Get All Enterprise",
        OperationId = "GetEnterprise",
        Tags = new []{"Enterprises"}
    )]
    public async Task<IEnumerable<EnterpriseResource>> GetAllSync()
    {
        var enterprises = await _enterpriseService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Enterprise>, IEnumerable<EnterpriseResource>>(enterprises);
        return resources;
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Post Enterprise",
        Description = "Save Enterprise In Database",
        OperationId = "PostEnterprise",
        Tags = new []{"Enterprises"}
    )]
    public async Task<IActionResult> PostAsync([FromBody] SaveEnterpriseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var enterprise = _mapper.Map<SaveEnterpriseResource, Enterprise>(resource);

        var result = await _enterpriseService.SaveAsync(enterprise);

        if (!result.Success)
            return BadRequest(result.Message);

        var categoryResource = _mapper.Map<Enterprise, EnterpriseResource>(result.Resource);

        return Ok(categoryResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Edit Enterprise",
        Description = "Edit Enterprise exiting in database",
        OperationId = "PutEnterprise",
        Tags = new []{"Enterprises"}
    )]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEnterpriseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var enterprise = _mapper.Map<SaveEnterpriseResource, Enterprise>(resource);

        var result = await _enterpriseService.UpdateAsync(id, enterprise);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var categoryResource = _mapper.Map<Enterprise, EnterpriseResource>(result.Resource);

        return Ok(categoryResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete Enterprise",
        Description = "Delete Enterprise By Id In Database",
        OperationId = "DeleteEnterprise",
        Tags = new []{"Enterprises"}
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _enterpriseService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var categoryResource = _mapper.Map<Enterprise, EnterpriseResource>(result.Resource);

        return Ok(categoryResource);
    }
}