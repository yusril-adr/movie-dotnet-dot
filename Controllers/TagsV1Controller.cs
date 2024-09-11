using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Contexts;
using NuGet.Protocol;
using dot_dotnet_test_api.Dtos;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Types;
using Humanizer;
using dot_dotnet_test_api.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;

namespace dot_dotnet_test_api.Controllers
{
    [Route("api/v1/backoffice/tags")]
    [ApiController]
    public class TagsV1Controller(SQLServerContext context, ILogger<TagsV1Controller> logger) : ControllerBase
    {
        private readonly SQLServerContext _context = context;
        private readonly ILogger<TagsV1Controller> _logger = logger;


        // GET: api/v1/backoffice/tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieV1>>> GetBackOfficeTags(MovieV1BackOfficeListDto movieV1BackOfficeListDto)
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}";
            var page = movieV1BackOfficeListDto.Page;
            var perPage = movieV1BackOfficeListDto.PerPage;
            var tagCount = await _context.Tags.CountAsync();
            var totalPage = (int) Math.Ceiling((double) tagCount / perPage);

            if (page > totalPage) {
                return new Response<object>(
                    message: "Get Box Office Tags Failed",
                    error: "page is out of range"
                ).GetFormated(StatusCodes.Status400BadRequest);
            }

            var offset = (movieV1BackOfficeListDto.Page - 1) * movieV1BackOfficeListDto.PerPage;
            var tagList = await _context.Tags
                // .Include(data => data.MovieTags)
                .Skip(offset)
                .Take(movieV1BackOfficeListDto.PerPage)
                .Select(tag => new {
                    tag.Id,
                    tag.Name,
                    movies = tag.MovieTag.Select((movieTag) => new { movieTag.Movie!.Id, movieTag.Movie!.Title })
                })
                .ToListAsync();

            return new PaginationResponse<object>(
                items: tagList,
                message: "Get Back Office Tags Success",
                pagination: new Pagination
                {
                    Page = movieV1BackOfficeListDto.Page,
                    PerPage = movieV1BackOfficeListDto.PerPage,
                    TotalItem = tagCount,
                    totalPages = totalPage,
                    PreviousPageLink = page == 1 ? null : $"{baseUri}?page={page - 1}&per_page={perPage}",
                    NextPageLink = page == totalPage ? null : $"{baseUri}?page={page + 1}&per_page={perPage}",
                }
            ).GetFormated();
        }    
     }
}
