using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Dtos;
public class MovieV1BackOfficeScheduleDto
{
    [JsonProperty("movie_id")]
    public int? MovieId { get; set; }

    [JsonProperty("studio_id")]
    public int? StudioId { get; set; }

    [JsonProperty("start_time")]
    public string? StartTime { get; set; }

    [JsonProperty("end_time")]
    public string? EndTime { get; set; }

    [JsonProperty("price")]
    public int? Price { get; set; }

    [JsonProperty("date")]
    public DateTime? Date { get; set; }
}