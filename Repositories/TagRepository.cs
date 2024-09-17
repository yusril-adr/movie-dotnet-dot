using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dot_dotnet_test_api.Repositories;

public class TagRepository(
  IConfiguration configuration,
  SQLServerContext context,
  ILogger<TagRepository> logger
)
{
  private readonly IConfiguration _configuration = configuration;

  private readonly SQLServerContext _context = context;
  private readonly ILogger<TagRepository> _logger = logger;

  public async Task<Tag?> FindById(long tagId) {
    var foundedTag = await _context.Tag.FindAsync(tagId);
    return foundedTag;
  }


  public async Task<List<Tag>> FindByIds(List<long> ids) {
    var foundedTag = await _context.Tag.Where(tag => ids.Contains((long) tag.Id!)).ToListAsync();
    return foundedTag;
  }

  public async Task<List<Tag>> FindAllPagination(int page, int perPage) {
    var offset = (page - 1) * perPage;

    var TagList = await _context.Tag
      .Skip(offset)
      .Take(perPage)
      .Select(tag => new Tag
      {
        Id = tag.Id,
        Name = tag.Name,
        CreatedAt = null,
        UpdatedAt = null
      })
      .ToListAsync();

    return TagList;
  }

  public async Task<int> Count() {
    return await _context.Tag.CountAsync();
  }

  public async Task DeleteMovieTagsByMovieId(long movieId) {
    await _context.MovieTags.Where((mt) => mt.Movie!.Id == movieId).ExecuteDeleteAsync();
  }
}
