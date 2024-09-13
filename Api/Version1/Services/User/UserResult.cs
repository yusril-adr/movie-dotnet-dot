
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
}

public class LoginResult : RegisterResult {
  [JsonProperty("_token")]
  public required string Token { get; set; }
}

public class LoginByIdResult : RegisterResult;
