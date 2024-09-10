using Newtonsoft.Json;

namespace dot_dotnet_test_api.Types
{
  public class IMoviePlaying {
    [JsonProperty("backdrop_path")]
    public string BackdropPath { get; set; }

    [JsonProperty("id")]
    public int TmdbId { get; set; }

    public string Title { get; set; }
    
    public string Overview { get; set; }
  }

  public class ITMDBNowPlaying {
    [JsonProperty("results")]
    public IMoviePlaying[] Results { get; set; }
  }
}