
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Repositories;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.API.Version1.Services;

public class StudioBestSellerResult {
  [JsonProperty("id")]
  public required long Id { get; set; }

  [JsonProperty("studio_number")]
  public required int StudioNumber { get; set; }

  [JsonProperty("seat_capacity")]
  public required int SeatCapacity { get; set; }

  [JsonProperty("total_ticket_sold")]
  public required int TotalTicketSold { get; set; }

  public static StudioBestSellerResult MapJson(StudioBestSeller studio) {
    return new StudioBestSellerResult {
      Id = studio.Id,
      StudioNumber = studio.StudioNumber,
      SeatCapacity = studio.SeatCapacity,
      TotalTicketSold = studio.TotalTicketSold,
    };
  }
}