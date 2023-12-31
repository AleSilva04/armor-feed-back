﻿
using ArmorFeedApi.Customers.Authorization.Attributes;
using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Customers.Domain.Services;
using ArmorFeedApi.Customers.Domain.Services.Communication;
using ArmorFeedApi.Customers.Resource;
using ArmorFeedApi.Security.Domain.Services.Communication;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ArmorFeedApi.Security.Authorization.Attributes;

namespace ArmorFeedApi.Customers.Controller;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class CustomersController: ControllerBase
{
    private readonly ICustomerService _userService;
    private readonly IMapper _mapper;

    public CustomersController(ICustomerService userService, IMapper mapper)
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
    public async Task<IActionResult> RegisterAsync(RegisterCustomerRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message ="Registration successful"});
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(users);
        return Ok(resources);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<Customer, CustomerResource>(user);
        return Ok(resource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateCustomerRequest request)
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