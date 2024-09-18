using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dot_dotnet_test_api.Repositories;

public class StudioBestSeller : Studio
{
  public new long Id { get; set; }
  public new int StudioNumber { get; set; }
  public new int SeatCapacity { get; set; }
  public int TotalTicketSold { get; set; }
}

public class StudioRepository(IConfiguration configuration, SQLServerContext context, ILogger<StudioRepository> logger)
{
  private readonly IConfiguration _configuration = configuration;

  private readonly SQLServerContext _context = context;
  private readonly ILogger<StudioRepository> _logger = logger;

  public async Task<Studio> Create(Studio studio)
  {
    _context.Studio.Add(studio);
    await _context.SaveChangesAsync();

    return studio;
  }

  public async Task<int> Count()
  {
    return await _context.Studio.CountAsync();
  }

  public async Task<List<Studio>> FindAllPagination(int page, int perPage)
  {
    var offset = (page - 1) * perPage;

    var StudioList = await _context.Studio
      .Skip(offset)
      .Take(perPage)
      .Select(studio => new Studio
      {
        Id = studio.Id,
        StudioNumber = studio.StudioNumber,
        SeatCapacity = studio.SeatCapacity,
        CreatedAt = null,
        UpdatedAt = null
      })
      .ToListAsync();

    return StudioList;
  }

  public async Task<Studio?> FindById(long studioId)
  {
    var foundedStudio = await _context.Studio.FindAsync(studioId);
    return foundedStudio;
  }

  private IQueryable<StudioBestSeller> QueryStudioBestSeller(DateOnly startDate, DateOnly endDate)
  {
    var query = from studio in _context.Studio
                join schedule in _context.MovieSchedule
                    on studio.Id equals schedule.StudioId into studioScheduleGroup
                from schedule in studioScheduleGroup.DefaultIfEmpty() // Ensure all studios are included
                join orderItem in _context.OrderItems
                    on schedule.Id equals orderItem.MovieScheduleId into scheduleOrderGroup
                from orderItem in scheduleOrderGroup
                  .Where(o => 
                      o.CreatedAt >= startDate.ToDateTime(TimeOnly.MinValue)
                      && o.CreatedAt <= endDate.ToDateTime(TimeOnly.MaxValue)
                  )
                  .DefaultIfEmpty() // Ensure studios with no orders are included
                group orderItem by studio into studioGroup
                select new StudioBestSeller
                {
                  Id = (long)studioGroup.Key.Id!,
                  StudioNumber = studioGroup.Key.StudioNumber,
                  SeatCapacity = studioGroup.Key.SeatCapacity,
                  TotalTicketSold = studioGroup.Sum(o => (int)o.Qty!) // Sum the Qty field
                } into result
                orderby result.TotalTicketSold descending // Order by total tickets sold
                select result;

    return query;
  }

  public async Task<List<StudioBestSeller>> FindStudioBestSeller(DateOnly startDate, DateOnly endDate, int page, int perPage)
  {
    var query = QueryStudioBestSeller(startDate, endDate);

    var offset = (page - 1) * perPage;
    return await query.Skip(offset).Take(perPage).ToListAsync();
  }

  public async Task<int> CountStudioBestSeller(DateOnly startDate, DateOnly endDate)
  {
    var query = QueryStudioBestSeller(startDate, endDate);

    return await query.CountAsync();
  }
}
