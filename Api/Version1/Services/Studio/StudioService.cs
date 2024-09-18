using Coravel.Queuing.Interfaces;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Repositories;
using dot_dotnet_test_api.Types;
using dot_dotnet_test_api.API.Version1.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace dot_dotnet_test_api.API.Version1.Services;

public class StudioService (
  IConfiguration configuration,
  StudioRepository studioRepository,
  IQueue queue,
  ILogger<StudioService> logger
)
{
  private readonly IConfiguration _configuration = configuration;
  private readonly StudioRepository _studioRepository = studioRepository;
  private readonly IQueue _queue = queue;

  private readonly ILogger<StudioService> _logger = logger;

  public async Task<ContentResult> GetStudios(PaginationDto paginationDto)
  {
    var page = paginationDto.Page;
    var perPage = paginationDto.PerPage;
    var tagCount = await _studioRepository.Count();
    var totalPage = (int)Math.Ceiling((double)tagCount / perPage);

    if (page > totalPage)
    {
      return new Response<object>(
          message: "Get Box Office Studios Failed",
          error: "page is out of range"
      ).GetFormated(StatusCodes.Status400BadRequest);
    }

    var studioList = await _studioRepository.FindAllPagination(page, perPage);

    return new PaginationResponse<List<Studio>>(
        items: studioList,
        message: "Get Back Office Studio Success",
        pagination: new Pagination
        {
          Page = page,
          PerPage = perPage,
          TotalItem = tagCount,
          TotalPages = totalPage
        }
    ).GetFormated();
  }

  public async Task<ContentResult> GetStudioBestSellerList(DateOnlyRangeDto dateOnlyRangeDto)
  {
    var page = dateOnlyRangeDto.Page;
    var perPage = dateOnlyRangeDto.PerPage;
    var startDate = (DateOnly) dateOnlyRangeDto.StartDate!;
    var endDate = (DateOnly) dateOnlyRangeDto.EndDate!;
    var tagCount = await _studioRepository.CountStudioBestSeller(startDate, endDate);
    var totalPage = (int) Math.Ceiling((double)tagCount / perPage);

    if (page > totalPage)
    {
      return new Response<object>(
          message: "Get Box Office Best Seller Studio Failed",
          error: "page is out of range"
      ).GetFormated(StatusCodes.Status400BadRequest);
    }

    var studioList = await _studioRepository.FindStudioBestSeller(startDate, endDate, page, perPage);

    return new PaginationResponse<List<StudioBestSellerResult>>(
        items: studioList.Select(StudioBestSellerResult.MapJson).ToList(),
        message: "Get Back Office Best Seller Studio Success",
        pagination: new Pagination
        {
          Page = page,
          PerPage = perPage,
          TotalItem = tagCount,
          TotalPages = totalPage
        }
    ).GetFormated();
  }
}
