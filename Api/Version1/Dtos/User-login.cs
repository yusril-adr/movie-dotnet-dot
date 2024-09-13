using System.ComponentModel.DataAnnotations;

namespace dot_dotnet_test_api.API.Version1.Dtos;
public class UserLoginDto
{
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}