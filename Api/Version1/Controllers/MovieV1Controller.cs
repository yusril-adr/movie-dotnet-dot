using Microsoft.AspNetCore.Mvc;
using dot_dotnet_test_api.Dtos;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.API.Version1.Validators;
using FluentValidation.Results;
using dot_dotnet_test_api.API.Version1.Services;

namespace dot_dotnet_test_api.API.Version1.Controllers
{
    [Route("api/v1/movies")]
    [ApiController]
    public class MovieController(MovieService movieService, ILogger<MovieController> logger) : ControllerBase
    {
        private readonly MovieService _movieService = movieService;
        private readonly ILogger<MovieController> _logger = logger;

        // GET: api/v1/movies
        [HttpGet]
        public async Task<ContentResult> GetMovieList(MovieListDto movieListDto)
        {
            var validator = new MovieListValidator();
            ValidationResult results = validator.Validate(movieListDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Get Movies Failed");
            
            return await _movieService.GetMovieListWithSchedules(movieListDto, Request);
        }
    }
}
