using Newtonsoft.Json;

namespace dot_dotnet_test_api.Types
{
  public class MoviePlaying {
    [JsonProperty("backdrop_path")]
    public required string BackdropPath { get; set; }

    [JsonProperty("id")]
    public required int TmdbId { get; set; }

    public required string Title { get; set; }
    
    public required string Overview { get; set; }
  }

  public class TMDBNowPlaying {
    [JsonProperty("results")]
    public MoviePlaying[] Results { get; set; } = [];
  }
}