using Newtonsoft.Json;

namespace dot_dotnet_test_api.Types
{
  public class MoviePlaying {
    [JsonProperty("backdrop_path")]
    public string BackdropPath { get; set; }

    [JsonProperty("id")]
    public int TmdbId { get; set; }

    public string Title { get; set; }
    
    public string Overview { get; set; }
  }

  public class TMDBNowPlaying {
    [JsonProperty("results")]
    public MoviePlaying[] Results { get; set; }
  }
}