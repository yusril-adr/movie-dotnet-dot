using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Dtos;

public class TransactionV1OrderItemDto {
    [JsonProperty("movie_schedule_id")]
    public int? MovieScheduleId { get; set; }

    [JsonProperty("qty")]
    public int? Qty { get; set; }
}

public class TransactionV1OrderDto
{
    [JsonProperty("items")]
    public TransactionV1OrderItemDto[]? Items { get; set; }
}