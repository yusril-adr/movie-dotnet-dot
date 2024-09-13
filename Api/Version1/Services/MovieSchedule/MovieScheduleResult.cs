
using dot_dotnet_test_api.Models;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.API.Version1.Services;

public class MovieResult {
  [JsonProperty("id")]
  public required long Id { get; set; }
  [JsonProperty("title")]
  public required string Title { get; set; }
}

public class StudioResult {
  [JsonProperty("id")]
  public required long Id { get; set; }
  [JsonProperty("studio_number")]
  public required int StudioNumber { get; set; }

  [JsonProperty("seat_remaining")]
  public required int SeatRemaining { get; set; }
}

public class CreateMovieScheduleResult {
  [JsonProperty("id")]
  public required long Id { get; set; }

  [JsonProperty("start_time")]
  public required string StartTime { get; set; }

  [JsonProperty("end_time")]
  public required string EndTime { get; set; }

  [JsonProperty("date")]
  public required DateOnly Date { get; set; }

  [JsonProperty("price")]
  public required int Price { get; set; }

  [JsonProperty("movie")]
  public required virtual MovieResult Movie { get; set; }

  [JsonProperty("studio")]
  public required virtual StudioResult Studio { get; set; }

  public static CreateMovieScheduleResult MapJson(MovieSchedule movieSchedule) {
    return new CreateMovieScheduleResult {
        Id =(long) movieSchedule.Id!,
        Movie = new MovieResult {
          Id = (long) movieSchedule.Movie!.Id!,
          Title = movieSchedule.Movie.Title!,
        },
        Studio = new StudioResult
        {
          Id = (long) movieSchedule.Studio!.Id!,
          StudioNumber = movieSchedule.Studio!.StudioNumber,
          SeatRemaining = movieSchedule.Studio.SeatCapacity,
        },
        StartTime = movieSchedule.StartTime,
        EndTime = movieSchedule.EndTime,
        Date = movieSchedule.Date,
        Price = movieSchedule.Price 
    };
  }
}
