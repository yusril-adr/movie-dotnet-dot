using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dot_dotnet_test_api.Repositories;

public class MovieScheduleRepository(
  IConfiguration configuration,
  SQLServerContext context,
  ILogger<MovieScheduleRepository> logger
)
{
  private readonly IConfiguration _configuration = configuration;

  private readonly SQLServerContext _context = context;
  private readonly ILogger<MovieScheduleRepository> _logger = logger;

   public async Task<MovieSchedule> Create(MovieSchedule movieSchedule) {
    _context.MovieSchedule.Add(movieSchedule);
    await _context.SaveChangesAsync();

    return movieSchedule;
  }

  public async Task<MovieSchedule?> FindById(long movieScheduleId) {
    var foundedSchedule = await _context.MovieSchedule
      .Include(x => x.Studio)
      .Where(x => x.Id == movieScheduleId)
      .SingleOrDefaultAsync();

    return foundedSchedule;
  }

  public async Task Update(MovieSchedule movieSchedule) {
    _context.MovieSchedule.Update(movieSchedule);
    await _context.SaveChangesAsync();
  }

  public async Task<List<MovieSchedule>> FindAvailableScheduleByDate(long movieId, long studioId, DateOnly date) {
    var results = await _context.MovieSchedule
        .Where(schedule =>
            schedule.Movie!.Id == movieId
            && schedule.Studio!.Id == studioId
            && schedule.Date == date
        ).ToListAsync();
  
    return results;
  }
}
