using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Dtos;
public class MovieBackOfficeUpdateDto
{
    [JsonProperty("title")]
    public string? Title { get; set; }
    [JsonProperty("overview")]
    public string? Overview { get; set; }
    [JsonProperty("poster")]
    public IFormFile? Poster { get; set; }

    // TODO for learning
    // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-DD HH:mm}")]
    [FromForm(Name = "play_until")]
    [JsonProperty("play_until")]
    public DateTime PlayUntil { get; set; }

    [JsonProperty("tags")]
    public long[]? Tags { get; set; } = [];
}