using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Dtos;
public class MovieV1BackOfficeListDto
{
    [JsonProperty("page")]
    public int Page { get; set; } = 1;
    [JsonProperty("per_page")]
    public int PerPage { get; set; } = 10;
}