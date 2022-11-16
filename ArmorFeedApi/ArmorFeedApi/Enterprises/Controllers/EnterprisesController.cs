using ArmorFeedApi.Enterprises.Authorization.Attributes;
using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Services;
using ArmorFeedApi.Enterprises.Domain.Services.Communication;
using ArmorFeedApi.Enterprises.Resources;
using ArmorFeedApi.Security.Authorization.Attributes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ArmorFeedApi.Security.Domain.Services.Communication;

namespace ArmorFeedApi.Enterprises.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class EnterprisesController: ControllerBase
{
    private readonly IEnterpriseService _userService;
    private readonly IMapper _mapper;
    
    public EnterprisesController(IEnterpriseService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest request)
    {
        var response = await _userService.Authenticate(request);
        return Ok(response);
    }
    
    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> RegisterAsync(RegisterEnterpriseRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message ="Registration successful"});
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Enterprise>, IEnumerable<EnterpriseResource>>(users);
        return Ok(resources);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<Enterprise, EnterpriseResource>(user);
        return Ok(resource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateEnterpriseRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }

}