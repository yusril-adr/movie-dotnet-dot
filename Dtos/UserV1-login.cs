using System.ComponentModel.DataAnnotations;

namespace dot_dotnet_test_api.Dtos;
public class UserV1LoginDto
{
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}