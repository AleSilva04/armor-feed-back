using System.Text.Json.Serialization;

namespace ArmorFeedApi.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public string Ruc { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }
}