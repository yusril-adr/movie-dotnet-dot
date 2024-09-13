
using dot_dotnet_test_api.Models;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.API.Version1.Services;

public class AvatarFileResult {
  public required string FilePath { get; set; }

  public required string SavedFileName { get; set; }
}

public class RegisterResult {
  public required long Id { get; set; }
  public required string Email { get; set; }
  public required string Name { get; set; }
  public required string Avatar { get; set; }

  public static RegisterResult MapJson(User user, string displayedAvatar) {
    return new RegisterResult {
      Id = user.Id,
      Email = user.Email,
      Name = user.Name,
      Avatar = displayedAvatar,
    };
  }
}

public class LoginResult : RegisterResult {
  [JsonProperty("_token")]
  public required string Token { get; set; }

  public static LoginResult MapJson(User user, string displayedAvatar, string token) {
    return new LoginResult {
      Id = user.Id,
      Email = user.Email,
      Name = user.Name,
      Avatar = displayedAvatar,
      Token = token
    };
  }
}

public class LoginByIdResult : RegisterResult {
public static new LoginByIdResult MapJson(User user, string displayedAvatar) {
    return new LoginByIdResult {
      Id = user.Id,
      Email = user.Email,
      Name = user.Name,
      Avatar = displayedAvatar,
    };
  }
}
