using System.ComponentModel.DataAnnotations;

namespace dot_dotnet_test_api.API.Version1.Dtos;
public class UserRegisterDto
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public required IFormFile Avatar { get; set; }
}