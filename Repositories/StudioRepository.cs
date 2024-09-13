using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dot_dotnet_test_api.Repositories;

public class StudioRepository(IConfiguration configuration, SQLServerContext context, ILogger<StudioRepository> logger)
{
  private readonly IConfiguration _configuration = configuration;

  private readonly SQLServerContext _context = context;
  private readonly ILogger<StudioRepository> _logger = logger;

  public async Task<Studio> Create(Studio studio) {
    _context.Studio.Add(studio);
    await _context.SaveChangesAsync();

    return studio;
  }

  public async Task<int> Count() {
    return await _context.Studio.CountAsync();
  }

  public async Task<List<Studio>> FindAllPagination(int page, int perPage) {
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

  public async Task<Studio?> FindById(long studioId) {
    var foundedStudio = await _context.Studio.FindAsync(studioId);
    return foundedStudio;
  }
}
