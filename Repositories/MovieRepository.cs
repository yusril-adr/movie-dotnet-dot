using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace dot_dotnet_test_api.Repositories;

public class BestSellerMovie : Movie
{
  public int TotalTicketsSold { get; set; }
  public List<Tag> Tags { get; set; } = [];
}

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

  public async Task<int> CountAll()
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

  private IQueryable<Movie> QueryWithSchedule(string? keyword, DateOnly? date)
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

    return movieQuery;
  }
  public async Task<int> FindAllWithScheduleCount(string? keyword, DateOnly? date)
  {
    var movieQuery = QueryWithSchedule(keyword, date);
    var count = await movieQuery.CountAsync();

    return count;
  }

  public async Task<List<Movie>> FindAllWithSchedulePagination(int page, int perPage, string? keyword, DateOnly? date)
  {
    var movieQuery = QueryWithSchedule(keyword, date);

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
          new MovieSchedule
          {
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

  private IOrderedQueryable<BestSellerMovie> QueryBestSellerList(DateOnly startDate, DateOnly endDate)
  {
    var query = from movie in _context.Movie
                join schedule in _context.MovieSchedule
                    on movie.Id equals schedule.MovieId into movieScheduleGroup
                from schedule in movieScheduleGroup
                  // .DefaultIfEmpty() // ? Enabled it if you want to show all schedule
                join orderItem in _context.OrderItems
                    on schedule.Id equals orderItem.MovieScheduleId into scheduleOrderGroup
                from orderItem in scheduleOrderGroup
                    .Where(o =>
                      o.CreatedAt >= startDate.ToDateTime(TimeOnly.MinValue)
                      && o.CreatedAt <= endDate.ToDateTime(TimeOnly.MaxValue)
                    )
                    // .DefaultIfEmpty() // ? enabled it if you want to show all totalTicketSold
                group orderItem by movie into movieGroup
                select new
                {
                  movieGroup.Key.Id,
                  movieGroup.Key.Title,
                  movieGroup.Key.Overview,
                  movieGroup.Key.Poster,
                  movieGroup.Key.PlayUntil,
                  movieGroup.Key.CreatedAt,
                  movieGroup.Key.UpdatedAt,
                  movieGroup.Key.DeletedAt,
                  TotalTicketsSold = movieGroup.Sum(o => o != null ? o.Qty : 0) // Sum tickets sold
                } into movieWithSales
                join movieTag in _context.MovieTags
                    on movieWithSales.Id equals movieTag.MovieId into movieTagGroup
                from movieTag in movieTagGroup
                  .DefaultIfEmpty()
                join tag in _context.Tag
                    on movieTag.TagId equals tag.Id into tagGroup
                from tag in tagGroup
                  .DefaultIfEmpty()
                group tag by movieWithSales into movieWithTagsGroup
                select new BestSellerMovie
                {
                  Id = movieWithTagsGroup.Key.Id,
                  Title = movieWithTagsGroup.Key.Title,
                  Overview = movieWithTagsGroup.Key.Overview,
                  Poster = movieWithTagsGroup.Key.Poster,
                  PlayUntil = movieWithTagsGroup.Key.PlayUntil,
                  CreatedAt = movieWithTagsGroup.Key.CreatedAt,
                  UpdatedAt = movieWithTagsGroup.Key.UpdatedAt,
                  DeletedAt = movieWithTagsGroup.Key.DeletedAt,
                  TotalTicketsSold = (int) movieWithTagsGroup.Key.TotalTicketsSold!,
                  Tags = movieWithTagsGroup.Where(g => g.Id != null)
                          .Select(g => new Tag { Id = g.Id, Name = g.Name })
                          .Distinct()
                          .ToList()
                } into result
                orderby result.TotalTicketsSold descending // Order by tickets sold
                select result;


    return query;
  }
  public async Task<List<BestSellerMovie>> FindBestSeller(DateOnly startDate, DateOnly endDate, int page, int perPage)
  {
    var query = QueryBestSellerList(startDate, endDate);

    // Apply Pagination: Skip and Take
    var offset = (page - 1) * perPage;
    var paginatedResult = await query
      .Skip(offset)
      .Take(perPage)
      .ToListAsync();

    // Console.WriteLine(paginatedResult)

    return paginatedResult;
  }

  public async Task<int> CountBestSellerList(DateOnly startDate, DateOnly endDate)
  {
    var query = QueryBestSellerList(
      startDate,
      endDate
    );
    var count = await query.CountAsync();

    return count;
  }
}
