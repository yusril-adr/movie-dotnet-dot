
using Newtonsoft.Json;

namespace dot_dotnet_test_api.API.Version1.Services;

public class TagListResult {
  [JsonProperty("id")]
  public required long Id { get; set; }
  [JsonProperty("name")]
  public required string Name { get; set; }
}
