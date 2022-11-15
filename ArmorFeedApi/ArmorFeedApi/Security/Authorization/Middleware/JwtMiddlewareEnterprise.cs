using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Customers.Domain.Services;
using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Services;
using ArmorFeedApi.Security.Authorization.Handlers.Interfaces;
using ArmorFeedApi.Security.Authorization.Settings;
using ArmorFeedApi.Security.Domain.Services;
using Microsoft.Extensions.Options;

namespace ArmorFeedApi.Security.Authorization.Middleware;

public class JwtMiddlewareEnterprise
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddlewareEnterprise(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IEnterpriseService userService, IJwtHandler<Enterprise> handler)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = handler.ValidateToken(token);
        if (userId != null)
        {
            // On success JWT validation, attach user to context
            context.Items["Enterprise"] = await userService.GetByIdAsync(userId.Value);
        }
        await _next(context);
    }

}