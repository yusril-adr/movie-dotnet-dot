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

        // GET: api/v1/backoffice/movies
        [HttpGet("/api/v1/backoffice/movies")]
        public async Task<ActionResult<IEnumerable<MovieV1>>> GetBackOfficeMovie(MovieV1BackOfficeListDto movieV1BackOfficeListDto)
        {
            var validator = new MovieV1BackOfficeListValidator();
            ValidationResult results = validator.Validate(movieV1BackOfficeListDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Get Back Office Movies Failed");

            var baseUri = $"{Request.Scheme}://{Request.Host}";
            var page = movieV1BackOfficeListDto.Page;
            var perPage = movieV1BackOfficeListDto.PerPage;
            var movieCount = await _context.Movies.CountAsync();
            var totalPage = (int) Math.Ceiling((double) movieCount / perPage);
            

            if (page > totalPage) {
                return new Response<object>(
                    message: "Get Box Office Movies Failed",
                    error: "page is out of range"
                ).GetFormated(StatusCodes.Status400BadRequest);
            }

            var offset = (movieV1BackOfficeListDto.Page - 1) * movieV1BackOfficeListDto.PerPage;
            var movieList = await _context.Movies
                .Skip(offset)
                .Take(movieV1BackOfficeListDto.PerPage)
                .Select(movie => new {
                    movie.Id,
                    movie.Title,
                    movie.Poster,
                    movie.PlayUntil,
                    movie.Overview,
                    tags = movie!.MovieTags!.Select((tag) => new { tag!.Tag!.Id, tag.Tag.Name })
                })
                .ToListAsync();


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
                        movie.tags
                    };
                }),
                message: "Get Back Office Movies Success",
                pagination: new Pagination
                {
                    Page = movieV1BackOfficeListDto.Page,
                    PerPage = movieV1BackOfficeListDto.PerPage,
                    TotalItem = movieCount,
                    totalPages = totalPage,
                    PreviousPageLink = page == 1 ? null : $"{requestWithPath}?{previousQuery}",
                    NextPageLink = (page + 1) > totalPage || totalPage == 0  ? null : $"{requestWithPath}?{nextQuery}",
                }
            ).GetFormated();
        }
    
        // POST: api/v1/backoffice/movies/schedule
        [HttpPost("/api/v1/backoffice/movies/schedule")]
        public async Task<ActionResult<IEnumerable<MovieScheduleV1>>> PostBackOfficeSchedule([FromBody] MovieV1BackOfficeScheduleDto movieV1BackOfficeScheduleDto)
        {
            var validator = new MovieV1BackOfficeScheduleValidator();
            ValidationResult results = validator.Validate(movieV1BackOfficeScheduleDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Add Schedule Movie Failed");

            var foundedMovie = await _context.Movies.FindAsync((long) movieV1BackOfficeScheduleDto.MovieId);
            if (foundedMovie == null) 
            {
                return new Response<object>(
                    error: "Movie Not Found",
                    message: "Add Schedule Movie Failed"
                ).GetFormated(statusCode: StatusCodes.Status404NotFound);
            }

            var foundedStudio = await _context.Studio.FindAsync((long) movieV1BackOfficeScheduleDto.StudioId);
            if (foundedStudio == null) 
            {
                return new Response<object>(
                    error: "Studio Not Found",
                    message: "Add Schedule Movie Failed"
                ).GetFormated(statusCode: StatusCodes.Status404NotFound);
            }

            var dtoDate = DateOnly.FromDateTime((DateTime) movieV1BackOfficeScheduleDto.Date);
            var foundedScheduler = await _context.Schedule
                .Where(schedule => 
                    schedule.Movie.Id == movieV1BackOfficeScheduleDto.MovieId
                    && schedule.Studio.Id == movieV1BackOfficeScheduleDto.StudioId
                    && schedule.Date == dtoDate
                ).ToListAsync();
            
            string? error = null;

            foundedScheduler.ForEach(scheduler => {
                var startTime = DateTime.Parse($"{scheduler.Date} {scheduler.StartTime}");
                var endTime = DateTime.Parse($"{scheduler.Date} {scheduler.EndTime}");

                var dtoTime = DateTime.Parse($"{DateOnly.FromDateTime((DateTime) movieV1BackOfficeScheduleDto.Date)} {movieV1BackOfficeScheduleDto.StartTime}");

               if (dtoTime >= startTime && dtoTime <= endTime) {
                    error = $"Schedule conflict with id {scheduler.Id}";
               }
            });

            if (error != null) {
                return new Response<object>(
                    error: error,
                    message: "Add Schedule Movie Failed"
                ).GetFormated(StatusCodes.Status400BadRequest);
            }

            var createdSchedule = new MovieScheduleV1 {
                Movie = foundedMovie,
                Studio = foundedStudio,
                StartTime = movieV1BackOfficeScheduleDto.StartTime,
                EndTime = movieV1BackOfficeScheduleDto.EndTime,
                Date = DateOnly.FromDateTime((DateTime) movieV1BackOfficeScheduleDto.Date),
                Price = (int) movieV1BackOfficeScheduleDto.Price,
                RemainingSeat = foundedStudio.SeatCapacity,
            };

            _context.Add<MovieScheduleV1>(createdSchedule);
            await _context.SaveChangesAsync();

            return new Response<object>(
                data: new {
                    createdSchedule.Id,
                    movie = new {
                        createdSchedule.Movie.Id,
                        createdSchedule.Movie.Title,
                    },
                    studio = new {
                        createdSchedule.Studio.Id,
                        studio_number = createdSchedule.Studio.StudioNumber,
                        seat_capacity = createdSchedule.Studio.SeatCapacity,
                    },
                    start_time = createdSchedule.StartTime,
                    end_time = createdSchedule.EndTime,
                    createdSchedule.Date,
                    createdSchedule.Price
                },
                message: "Add Schedule Movie Success"
            ).GetFormated(StatusCodes.Status201Created);
        }

        // PUT: api/v1/backoffice/movies/{movieId}
        [HttpPut("/api/v1/backoffice/movies/{movieId}")]
        public async Task<ActionResult<IEnumerable<MovieV1>>> PutBackOfficeMovie(long movieId, [FromForm] MovieV1BackOfficeUpdateDto movieV1BackOfficeUpdateDto)
        {
            var validator = new MovieV1BackOfficeUpdateValidator();
            ValidationResult results = validator.Validate(movieV1BackOfficeUpdateDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Update Movie Failed");

            var foundedMovie = await _context.Movies.FindAsync(movieId);

            if (foundedMovie == null) 
            {
                return new Response<object>(
                    error: "Movie Not Found",
                    message: "Update Movie Failed"
                ).GetFormated(statusCode: StatusCodes.Status404NotFound);
            }


            var movieTags = new MovieTagsV1[movieV1BackOfficeUpdateDto.Tags.Length];

            int i = 0;
            string[] errors = [];
            foreach (var tag in movieV1BackOfficeUpdateDto.Tags)
            {
                var foundedTag = await _context.Tags.FindAsync(tag);

                if (foundedTag == null) {
                    errors.Append($"Tag with id {tag} Not Found");
                }

                var movieTag = new MovieTagsV1 {
                    Tag = foundedTag,
                    Movie = foundedMovie,
                };

                movieTags[i++] = movieTag;
            }

            if (errors.Length > 0) {
                return new Response<object>(
                    error: errors[0],
                    message: "Update Movie Failed"
                ).GetFormated(statusCode: StatusCodes.Status404NotFound);
            }

            _context.MovieTags.Where((mt) => mt.Movie!.Id == movieId).ExecuteDelete();

            foundedMovie.Title = movieV1BackOfficeUpdateDto!.Title;
            foundedMovie.Overview = movieV1BackOfficeUpdateDto!.Overview;
            foundedMovie.PlayUntil = movieV1BackOfficeUpdateDto.PlayUntil;
            foundedMovie.MovieTags = movieTags;
            foundedMovie.UpdatedAt = DateTime.Now;

            var fileName = foundedMovie.Poster.Split("/")[^1];

            if (movieV1BackOfficeUpdateDto.Poster != null) {
                var splittedFileNames = movieV1BackOfficeUpdateDto.Poster.FileName.Split(".");
                var fileExtension = splittedFileNames[splittedFileNames.Length - 1];
                var filePath = Path.Combine("./files/images/poster", Path.GetRandomFileName() + "-movie" + "." + fileExtension);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await movieV1BackOfficeUpdateDto.Poster.CopyToAsync(stream);
                }

                var savedSplitedFileNames = filePath.Split('/');
                var savedFileName = savedSplitedFileNames[^1];
                fileName = savedFileName;
                foundedMovie.Poster = filePath;
            }

            var baseUri = $"{Request.Scheme}://{Request.Host}";
            var deployedFilePath = $"{baseUri}/images/poster/{fileName}";

            _context.Update<MovieV1>(foundedMovie);
            await _context.SaveChangesAsync();

            return new Response<object>(
                data: new {
                    foundedMovie.Id,
                    foundedMovie.Title,
                    poster = foundedMovie.Poster.StartsWith("./") ? deployedFilePath : foundedMovie.Poster,
                    foundedMovie.PlayUntil,
                    foundedMovie.Overview,
                    tags = foundedMovie!.MovieTags.Select((tag) => new { tag.Tag!.Id, tag.Tag.Name }),
                },
                message: "Update Movie Success"
            ).GetFormated(statusCode: StatusCodes.Status200OK); ;
        }
    }
}
