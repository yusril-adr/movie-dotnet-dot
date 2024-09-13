using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Dtos;
public class MovieV1BackOfficeListDto
{
    [FromQuery(Name = "page")]
    [JsonProperty("page")]
    public int Page { get; set; } = 1;
    [FromQuery(Name = "per_page")]
    [JsonProperty("per_page")]
    public int PerPage { get; set; } = 10;
}