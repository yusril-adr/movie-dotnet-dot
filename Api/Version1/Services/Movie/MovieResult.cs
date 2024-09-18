
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Repositories;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.API.Version1.Services;

public class MovieTagResult {
  [JsonProperty("id")]
  public required long Id { get; set; }

  [JsonProperty("name")]
  public required string Name { get; set; }
}

public class MovieScheduleResult {
    [JsonProperty("id")]
  public required long Id { get; set; }

  [JsonProperty("start_time")]
  public required string StartName { get; set; }


  [JsonProperty("end_time")]
  public required string EndTime { get; set; }

  [JsonProperty("studio_number")]
  public required int StudioNumber { get; set; }

  [JsonProperty("seat_remaining")]
  public required int SeatRemaining { get; set; }

  [JsonProperty("price")]
  public required int Price { get; set; }
}

public class MovieListResult {
  [JsonProperty("id")]
  public required long Id { get; set; }

  [JsonProperty("title")]
  public required string Title { get; set; }

  [JsonProperty("poster")]
  public required string Poster { get; set; }

  [JsonProperty("overview")]
  public required string Overview { get; set; }

  [JsonProperty("play_until")]
  public required DateTime PlayUntil { get; set; }

  [JsonProperty("tags")]
  public virtual MovieTagResult[] Tags { get; set; } = [];

  public static MovieListResult MapJson(Movie movie) {
    return new MovieListResult {
      Id = (long) movie.Id!,
      Title = movie.Title!,
      Poster = movie.Poster!,
      Overview = movie.Overview!,
      PlayUntil = (DateTime) movie.PlayUntil!,
      Tags = movie!.MovieTags!.Select((tag) =>
        new MovieTagResult{
          Id = (long) tag.Tag!.Id!,
          Name = tag.Tag!.Name!
        }).ToArray(),
    };
  }
}

public class BestSellerMovieListResult: MovieListResult {
  [JsonProperty("tags")]
  public new virtual MovieTagResult[] Tags { get; set; } = [];
  
  [JsonProperty("total_ticket_sold")]
  public int TotalTicketsSold { get; set; }

  public static BestSellerMovieListResult MapJson(BestSellerMovie movie) {
    return new BestSellerMovieListResult {
      Id = (long) movie.Id!,
      Title = movie.Title!,
      Poster = movie.Poster!,
      Overview = movie.Overview!,
      PlayUntil = (DateTime) movie.PlayUntil!,
      TotalTicketsSold = movie.TotalTicketsSold,
      Tags = movie.Tags.Select(tag => new MovieTagResult { Id = (long) tag.Id!, Name = tag.Name! }).ToArray(),
    };
  }
}


public class MovieUpdateResult: MovieListResult {
  public static MovieUpdateResult MapJson(Movie movie, string deployedFilePath) {
    return new MovieUpdateResult {
      Id = (long) movie.Id!,
      Title = movie.Title!,
      Poster = movie.Poster!.StartsWith("./") ? deployedFilePath : movie.Poster,
      Overview = movie.Overview!,
      PlayUntil = (DateTime) movie.PlayUntil!,
      Tags = movie!.MovieTags!.Select((tag) =>
        new MovieTagResult{
          Id = (long) tag.Tag!.Id!,
          Name = tag.Tag!.Name!
        }).ToArray(),
    };
  }
}

public class MovieListWithScheduleResult: MovieListResult {
  [JsonProperty("schedules")]
  public virtual MovieScheduleResult[] Schedules { get; set; } = [];

  public static new MovieListWithScheduleResult MapJson(Movie movie) {
    return new MovieListWithScheduleResult {
      Id = (long) movie.Id!,
      Title = movie.Title!,
      Poster = movie.Poster!,
      Overview = movie.Overview!,
      PlayUntil = (DateTime) movie.PlayUntil!,
      Tags = movie!.MovieTags!.Select((tag) =>
        new MovieTagResult{
          Id = (long) tag.Tag!.Id!,
          Name = tag.Tag!.Name!
        }).ToArray(),
      Schedules = movie.MovieSchedules!.Select((schedule) => 
        new MovieScheduleResult {
          Id = (long) schedule.Id!,
          StartName = schedule.StartTime,
          EndTime = schedule.EndTime,
          StudioNumber = schedule.Studio!.StudioNumber,
          SeatRemaining = (int) schedule.RemainingSeat!,
          Price = schedule.Price
        }).ToArray(),
    };
  }
}
