using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Dtos;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Types;

namespace dot_dotnet_test_api.Controllers
{
    [Route("api/v1/backoffice/studios")]
    [ApiController]
    public class StudioV1Controller(SQLServerContext context, ILogger<StudioV1Controller> logger) : ControllerBase
    {
        private readonly SQLServerContext _context = context;
        private readonly ILogger<StudioV1Controller> _logger = logger;


        // GET: api/v1/backoffice/tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieV1>>> GetBackOfficeStudios(MovieV1BackOfficeListDto movieV1BackOfficeListDto)
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}";
            var page = movieV1BackOfficeListDto.Page;
            var perPage = movieV1BackOfficeListDto.PerPage;
            var tagCount = await _context.Studio.CountAsync();
            var totalPage = (int) Math.Ceiling((double) tagCount / perPage);

            if (page > totalPage) {
                return new Response<object>(
                    message: "Get Box Office Studios Failed",
                    error: "page is out of range"
                ).GetFormated(StatusCodes.Status400BadRequest);
            }

            var offset = (movieV1BackOfficeListDto.Page - 1) * movieV1BackOfficeListDto.PerPage;
            var tagList = await _context.Studio
                .Skip(offset)
                .Take(movieV1BackOfficeListDto.PerPage)
                .Select(studio => new {
                    studio.Id,
                    studio_number = studio.StudioNumber,
                    seat_capacity = studio.SeatCapacity,
                })
                .ToListAsync();

            return new PaginationResponse<object>(
                items: tagList,
                message: "Get Back Office Studio Success",
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
