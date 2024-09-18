using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Dtos;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Types;
using dot_dotnet_test_api.API.Version1.Validators;
using FluentValidation.Results;
using EFCore.BulkExtensions;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using dot_dotnet_test_api.API.Version1.Services;
using dot_dotnet_test_api.API.Version1.Dtos;

namespace dot_dotnet_test_api.API.Version1.Controllers
{
    [Route("api/v1/backoffice")]
    [ApiController]
    public class BackOfficeController(
        SQLServerContext context,
        MovieService movieService,
        StudioService studioService,
        TagService tagService,
        MovieScheduleService movieScheduleService,
        OrderService orderService,
        ILogger<BackOfficeController> logger
    ) : ControllerBase
    {
        private readonly SQLServerContext _context = context;
        private readonly ILogger<BackOfficeController> _logger = logger;
        private readonly MovieService _movieService = movieService;
        private readonly StudioService _studioService = studioService;
        private readonly TagService _tagService = tagService;
        private readonly OrderService _orderService = orderService;
        private readonly MovieScheduleService _movieScheduleService = movieScheduleService;

        // GET: api/v1/backoffice/studios
        [HttpGet("studios")]
        public async Task<ContentResult> GetBackOfficeStudios(PaginationDto paginationDto)
        {
            var validator = new PaginationValidator();
            ValidationResult results = validator.Validate(paginationDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Get BackOffice Studios Failed");

            return await _studioService.GetStudios(paginationDto);
        }   

        // GET: api/v1/backoffice/studios/best-seller
        [HttpGet("studios/best-seller")]
        public async Task<ContentResult> GetBackOfficeStudioBestSeller(DateOnlyRangeDto dateOnlyRangeDto)
        {
            var validator = new DateOnlyValidator();
            ValidationResult results = validator.Validate(dateOnlyRangeDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Get Back Office Best Seller Studio Failed");

            return await _studioService.GetStudioBestSellerList(dateOnlyRangeDto);
        }     

        // GET: api/v1/backoffice/movies
        [HttpGet("movies")]
        public async Task<ContentResult> GetBackOfficeMovie(PaginationDto paginationDto)
        {
            var validator = new PaginationValidator();
            ValidationResult results = validator.Validate(paginationDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Get Back Office Movies Failed");

            return await _movieService.GetMovieList(paginationDto, Request);
        }
        
        // GET: api/v1/backoffice/movies/best-seller
        [HttpGet("movies/best-seller")]
        public async Task<ContentResult> GetBackOfficeBestSellerMovie(DateOnlyRangeDto dateOnlyRangeDto)
        {
            var validator = new DateOnlyValidator();
            ValidationResult results = validator.Validate(dateOnlyRangeDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Get Back Office Best Seller Movies Failed");

            return await _movieService.GetBestSellerMovieList(dateOnlyRangeDto, Request);
        }
        

        // GET: api/v1/backoffice/tags
        [HttpGet("tags")]
        public async Task<ContentResult> GetBackOfficeTags(PaginationDto paginationDto)
        {
            var validator = new PaginationValidator();
            ValidationResult results = validator.Validate(paginationDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Get Back Office Tags Failed");

            return await _tagService.GetTags(paginationDto);
        }    

        // POST: api/v1/backoffice/movies/schedule
        [HttpPost("movies/schedule")]
        public async Task<ContentResult> PostBackOfficeSchedule([FromBody] MovieScheduleCreateDto movieScheduleCreateDto)
        {
            var validator = new MovieScheduleCreateValidator();
            ValidationResult results = validator.Validate(movieScheduleCreateDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Add Schedule Movie Failed");

            return await _movieScheduleService.CreateMovieSchedule(movieScheduleCreateDto);
        }

        // PUT: api/v1/backoffice/movies/{movieId}
        [HttpPut("movies/{movieId}")]
        public async Task<ContentResult> PutBackOfficeMovie(long movieId, [FromForm] MovieBackOfficeUpdateDto movieBackOfficeUpdateDto)
        {
            var validator = new MovieBackOfficeUpdateValidator();
            ValidationResult results = validator.Validate(movieBackOfficeUpdateDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Update Movie Failed");

            return await _movieService.UpdateMovie(movieId, movieBackOfficeUpdateDto, Request);
        }
    
        // GET: api/v1/backoffice/incomes
        [HttpGet("incomes")]
        public async Task<ContentResult> GetBackOfficeIncome(DateOnlyRangeDto dateOnlyRangeDto)
        {
            var validator = new DateOnlyValidator();
            ValidationResult results = validator.Validate(dateOnlyRangeDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Get Back Office Income Per date Failed");

            return await _orderService.GetIncomePerDate(dateOnlyRangeDto);
        }    
    }
}
