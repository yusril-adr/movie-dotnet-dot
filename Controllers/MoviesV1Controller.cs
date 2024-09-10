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

namespace dot_dotnet_test_api.Controllers
{
    [Route("api/v1/movies")]
    [ApiController]
    public class MoviesV1Controller(SQLServerContext context, ILogger<MoviesV1Controller> logger) : ControllerBase
    {
        private readonly SQLServerContext _context = context;
        private readonly ILogger<MoviesV1Controller> _logger = logger;


        // GET: api/v1/backoffice/movie
        [HttpGet("/api/v1/backoffice/movies")]
        public async Task<ActionResult<IEnumerable<MovieV1>>> GetBackOfficeMovie([FromQuery] MovieV1BackOfficeListDto movieV1BackOfficeListDto)
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}";
            var page = movieV1BackOfficeListDto.Page;
            var perPage = movieV1BackOfficeListDto.PerPage;
            var movieCount = await _context.Movies.CountAsync();
            decimal totalPagesDec = (movieCount / perPage);
            var totalPages = Convert.ToInt32(Math.Round(totalPagesDec));

            if (page > totalPages) {
                return new Response<object>(
                    message: "Get Box Office Movies Failed",
                    error: "page is out of range"
                ).GetFormated(StatusCodes.Status400BadRequest);
            }

            var offset = (movieV1BackOfficeListDto.Page - 1) * movieV1BackOfficeListDto.PerPage;
            var movieList = await _context.Movies
                .Skip(offset)
                .Take(movieV1BackOfficeListDto.PerPage)
                .Select(movie => new MovieV1{
                    Id = movie.Id,
                    Title = movie.Title,
                    Poster = movie.Poster,
                    PlayUntil = movie.PlayUntil,
                    Overview = movie.Overview,
                    CreatedAt = null,
                    UpdatedAt = null,
                    DeletedAt = null
                })
                .ToListAsync();

            return new PaginationResponse<List<MovieV1>>(
                items: movieList,
                message: "Get Back Office Movies Success",
                pagination: new Pagination
                {
                    Page = movieV1BackOfficeListDto.Page,
                    PerPage = movieV1BackOfficeListDto.PerPage,
                    TotalItem = movieCount,
                    totalPages = totalPages,
                    PreviousPageLink = page == 1 ? null : $"{baseUri}?page={page - 1}&per_page={perPage}",
                    NextPageLink = page == totalPages  ? null : $"{baseUri}?page={page + 1}&per_page={perPage}",
                }
            ).GetFormated();
        }
    }
}
