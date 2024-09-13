
using Newtonsoft.Json;

namespace dot_dotnet_test_api.API.Version1.Services;

public class PreviewOrderDetailResult {
  [JsonProperty("studio_number")]
  public required int StudioNumber { get; set; }

  [JsonProperty("qty")]
  public required int Qty { get; set; }

  [JsonProperty("sub_total_price")]
  public required int SubTotalPrice { get; set; }

  [JsonProperty("start_time")]
  public required string StartTime { get; set; }

  [JsonProperty("end_time")]
  public required string EndTime { get; set; }
}

public class PreviewOrderResult {
  [JsonProperty("total_qty")]
  public required int TotalQty { get; set; }

  [JsonProperty("total_price")]
  public required int TotalPrice { get; set; }  

  [JsonProperty("item_details")]
  public PreviewOrderDetailResult[] ItemDetails { get; set; } = [];
}