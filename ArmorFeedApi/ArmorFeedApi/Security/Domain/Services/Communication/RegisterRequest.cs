using System.ComponentModel.DataAnnotations;

namespace ArmorFeedApi.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required] public string Name { get; set; }
               public string Photo { get; set; }
    [Required] public string Ruc { get; set; }
    [Required] public string PhoneNumber { get; set; }
    [Required] public string Description { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}