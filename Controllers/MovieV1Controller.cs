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
using EFCore.BulkExtensions;
using System.Globalization;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;

namespace dot_dotnet_test_api.Controllers
{
    [Route("api/v1/movies")]
    [ApiController]
    public class MovieV1Controller(SQLServerContext context, ILogger<MovieV1Controller> logger) : ControllerBase
    {
        private readonly SQLServerContext _context = context;
        private readonly ILogger<MovieV1Controller> _logger = logger;

        // GET: api/v1/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieV1>>> GetMovieList(MovieV1ListDto movieV1ListDto)
        {
            var page = movieV1ListDto.Page;
            var perPage = movieV1ListDto.PerPage;

            IQueryable<MovieV1> movieQuery = _context.Movies;

            if (movieV1ListDto.Keyword != null) {
                movieQuery = movieQuery.Where(movie => EF.Functions.Like(movie.Title, $"%{movieV1ListDto.Keyword}%"));
            }

            if (movieV1ListDto.Date != null) {
                movieQuery = movieQuery.Where(movie => 
                    movie.MovieSchedules.Where(schedule => schedule.Date == movieV1ListDto.Date).ToArray().Length > 0
                );
            }

            var movieCount = await movieQuery.CountAsync();
            var totalPage = (int) Math.Ceiling((double) movieCount / perPage);

            if (page > totalPage && totalPage != 0 && page > 1) {
                return new Response<object>(
                    message: "Get Box Office Movies Failed",
                    error: "page is out of range"
                ).GetFormated(StatusCodes.Status400BadRequest);
            }

            var offset = (page - 1) * perPage;
            var movieList = await movieQuery
                .Skip(offset)
                .Take(perPage)
                .Select(movie => new {
                    movie.Id,
                    movie.Title,
                    movie.Poster,
                    movie.PlayUntil,
                    movie.Overview,
                    tags = movie!.MovieTags!.Select((tag) => new { tag!.Tag!.Id, tag.Tag.Name }),
                    schedule = movie.MovieSchedules!.Select((schedule) => new {
                        schedule.Price,
                        studio_number = schedule.Studio!.StudioNumber,
                        start_time = schedule.StartTime,
                        end_time = schedule.EndTime,
                        remaining_seat = schedule.RemainingSeat,
                    })
                })
                .ToListAsync();

            var baseUri = $"{Request.Scheme}://{Request.Host}";
            string requestWithPath = Request.GetDisplayUrl();
            requestWithPath = requestWithPath.Substring(0, requestWithPath.IndexOf("?"));
            var currentUri = new UriBuilder(Request.GetDisplayUrl());

            var previousQuery = HttpUtility.ParseQueryString(currentUri.Query);
            previousQuery.Set(HttpUtility.UrlEncode("page"), (page - 1).ToString());

            var nextQuery = HttpUtility.ParseQueryString(currentUri.Query);
            nextQuery.Set(HttpUtility.UrlEncode("page"), (page + 1).ToString());


            return new PaginationResponse<object>(
                items: movieList.Select(movie => {
                    var splittedFileNames = movie.Poster.Split(".");
                    var fileExtension = splittedFileNames[^1];
                    var deployedFilePath = $"{baseUri}/images/poster/{movie.Poster.Split("/")[^1]}";
                    return new {
                        movie.Id,
                        movie.Title,
                        poster = movie.Poster.StartsWith("./") ? deployedFilePath : movie.Poster,
                        movie.PlayUntil,
                        movie.Overview,
                        movie.tags,
                        movie.schedule,
                    };
                }),
                message: "Get Back Office Movies Success",
                pagination: new Pagination
                {
                    Page = page,
                    PerPage = perPage,
                    TotalItem = movieCount,
                    totalPages = totalPage,
                    PreviousPageLink = page == 1 ? null : $"{requestWithPath}?{previousQuery}",
                    NextPageLink = (page + 1) > totalPage || totalPage == 0  ? null : $"{requestWithPath}?{nextQuery}",
                }
            ).GetFormated();
        }
    }
}
