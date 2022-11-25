using ArmorFeedApi.Security.Domain.Models;

namespace ArmorFeedApi.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler <T>
{
    public string GenerateToken(T user);
    public int? ValidateToken(string token);
}