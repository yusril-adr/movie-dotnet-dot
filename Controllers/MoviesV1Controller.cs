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
        public async Task<ActionResult<IEnumerable<MovieV1>>> GetBackOfficeMovie(MovieV1BackOfficeListDto movieV1BackOfficeListDto)
        {
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



            return new PaginationResponse<object>(
                items: movieList.Select(movie => {
                    var splittedFileNames = movie.Poster.Split(".");
                    var fileExtension = splittedFileNames[^1];

                    var baseUri = $"{Request.Scheme}://{Request.Host}";
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
                    PreviousPageLink = page == 1 ? null : $"{baseUri}?page={page - 1}&per_page={perPage}",
                    NextPageLink = page == totalPage  ? null : $"{baseUri}?page={page + 1}&per_page={perPage}",
                }
            ).GetFormated();
        }
    
        // PUT: api/v1/backoffice/movie/{movieId}
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
