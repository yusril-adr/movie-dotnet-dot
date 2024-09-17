using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace dot_dotnet_test_api.Repositories;

public class MovieRepository(
  IConfiguration configuration,
  SQLServerContext context,
  ILogger<MovieRepository> logger
)
{
  private readonly IConfiguration _configuration = configuration;

  private readonly SQLServerContext _context = context;
  private readonly ILogger<MovieRepository> _logger = logger;

  public async Task<Movie?> FindById(long movieId)
  {
    var foundedMovie = await _context.Movie
      .Where(x => x.Id == movieId)
      .SingleOrDefaultAsync();

    return foundedMovie;
  }

  public async Task<int> Count()
  {
    return await _context.Movie.CountAsync();
  }

  public async Task Update(Movie movie)
  {
    _context.Movie.Update(movie);
    await _context.SaveChangesAsync();
  }

  public async Task<List<Movie>> FindAllPagination(int page, int perPage)
  {
    var offset = (page - 1) * perPage;

    var movieList = await _context.Movie
        .Skip(offset)
        .Take(perPage)
        .Select(movie => new Movie
        {
          Id = movie.Id,
          Title = movie.Title,
          Overview = movie.Overview,
          Poster = movie.Poster,
          PlayUntil = movie.PlayUntil,
          // Didnt use Include() because it will trigger loop reference
          MovieTags = movie.MovieTags!.Select((tag) => new MovieTags { Movie = movie, Tag = tag.Tag }).ToList()
        })
        .ToListAsync();

    return movieList;
  }

  public async Task<int> FindAllWithScheduleCount(string? keyword, DateOnly? date)
  {
    IQueryable<Movie> movieQuery = _context.Movie;

    if (!string.IsNullOrEmpty(keyword))
    {
      movieQuery = movieQuery.Where(movie => EF.Functions.Like(movie.Title, $"%{keyword}%"));
    }

    if (date != null)
    {
      movieQuery = movieQuery.Where(movie =>
          movie.MovieSchedules!.Where(schedule => schedule.Date == date).ToArray().Length > 0
      );
    }

    var movieCount = await movieQuery.CountAsync();
    return movieCount;
  }

  public async Task<List<Movie>> FindAllWithSchedulePagination(int page, int perPage, string? keyword, DateOnly? date)
  {
    IQueryable<Movie> movieQuery = _context.Movie;

    if (keyword != null)
    {
      movieQuery = movieQuery.Where(movie => EF.Functions.Like(movie.Title, $"%{keyword}%"));
    }

    if (date != null)
    {
      movieQuery = movieQuery.Where(movie =>
          movie.MovieSchedules!.Where(schedule => schedule.Date == date).ToArray().Length > 0
      );
    }

    var offset = (page - 1) * perPage;
    var movieList = await movieQuery
      .Skip(offset)
      .Take(perPage)
      .Select(movie => new Movie
      {
        Id = movie.Id,
        Title = movie.Title,
        Overview = movie.Overview,
        Poster = movie.Poster,
        // Didnt use Include() because it will trigger loop reference
        MovieTags = movie.MovieTags!.Select((tag) => new MovieTags { Movie = movie, Tag = tag.Tag }).ToList(),
        MovieSchedules = movie.MovieSchedules!.Select(schedule =>
          new MovieSchedule {
            Id = schedule.Id,
            StartTime = schedule.StartTime,
            EndTime = schedule.EndTime,
            Price = schedule.Price,
            Date = schedule.Date,
            RemainingSeat = schedule.RemainingSeat,
            Studio = schedule.Studio
          }
        ).ToList(),
      })
      .ToListAsync();

    return movieList;
  }
}
