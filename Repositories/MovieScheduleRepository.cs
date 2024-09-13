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

  public async Task<MovieScheduleV1?> FindById(long movieScheduleId) {
    var foundedSchedule = await _context.MovieSchedule
      .Include(x => x.Studio)
      .Where(x => x.Id == movieScheduleId)
      .SingleOrDefaultAsync();

    return foundedSchedule;
  }

  public async Task Update(MovieScheduleV1 movieSchedule) {
    _context.MovieSchedule.Update(movieSchedule);
    await _context.SaveChangesAsync();
  }
}
