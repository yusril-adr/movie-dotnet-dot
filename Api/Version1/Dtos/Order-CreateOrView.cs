using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.API.Version1.Dtos;

public class OrderItemDto {
    [JsonProperty("movie_schedule_id")]
    public int? MovieScheduleId { get; set; }

    [JsonProperty("qty")]
    public int? Qty { get; set; }
}

public class OrderCreateOrViewDto
{
    [JsonProperty("items")]
    public OrderItemDto[]? Items { get; set; }
}