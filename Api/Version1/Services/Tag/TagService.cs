using Coravel.Queuing.Interfaces;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Repositories;
using dot_dotnet_test_api.Types;
using dot_dotnet_test_api.API.Version1.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace dot_dotnet_test_api.API.Version1.Services;

public class TagService(
  IConfiguration configuration,
  TagRepository tagRepository,
  IQueue queue,
  ILogger<TagService> logger
)
{
  private readonly IConfiguration _configuration = configuration;
  private readonly TagRepository _tagRepository = tagRepository;
  private readonly IQueue _queue = queue;

  private readonly ILogger<TagService> _logger = logger;

  public async Task<ContentResult> GetTags(PaginationDto paginationDto)
  {
    var page = paginationDto.Page;
    var perPage = paginationDto.PerPage;
    var tagCount = await _tagRepository.Count();
    var totalPage = (int)Math.Ceiling((double)tagCount / perPage);

    if (page > totalPage)
    {
      return new Response<object>(
          message: "Get Box Office Tags Failed",
          error: "page is out of range"
      ).GetFormated(StatusCodes.Status400BadRequest);
    }

    var tagList = await _tagRepository.FindAllPagination(page, perPage);
    
    return new PaginationResponse<TagListResult[]>(
      items: tagList.Select(tag => new TagListResult {
        Id = (long) tag.Id!,
        Name = tag.Name!
      }).ToArray(),
      message: "Get Back Office Tags Success",
      pagination: new Pagination
      {
        Page = page,
        PerPage = perPage,
        TotalItem = tagCount,
        TotalPages = totalPage,
      }
    ).GetFormated();
  }
}
