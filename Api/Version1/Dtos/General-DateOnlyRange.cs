using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.API.Version1.Dtos;
public class DateOnlyRangeDto : PaginationDto
{
    [FromQuery(Name = "start_date")]
    [JsonProperty("start_date")]
    public DateOnly? StartDate { get; set; }
    [FromQuery(Name = "end_date")]
    [JsonProperty("end_date")]
    public DateOnly? EndDate { get; set; }
}