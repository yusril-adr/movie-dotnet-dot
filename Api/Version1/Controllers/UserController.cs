using Microsoft.AspNetCore.Mvc;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Helpers;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using dot_dotnet_test_api.API.Version1.Validators;
using dot_dotnet_test_api.API.Version1.Services;
using dot_dotnet_test_api.API.Version1.Dtos;

namespace dot_dotnet_test_api.API.Version1.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class UserController(
        ILogger<UserController> logger,
        UserService userService
    ) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly UserService _userService = userService;


        // POST: api/v1/register
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("register")]
        public async Task<ContentResult> Register([FromForm] UserRegisterDto userV1RegisterDto)
        {
            var validator = new UserRegisterDtoValidator();
            ValidationResult results = validator.Validate(userV1RegisterDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Registration Failed.");

            return await _userService.Register(userV1RegisterDto, Request);
        }

        // POST: api/v1/login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("login")]
        public async Task<ContentResult> Login(UserLoginDto userLoginDto)
        {
            var validator = new UserLoginDtoValidator();
            ValidationResult results = validator.Validate(userLoginDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results);

            return await _userService.Login(userLoginDto, Request);
        }

        // POST: api/v1/login/token
        [HttpPost("login/token")]
        [Authorize]
        public async Task<ActionResult<User>> LoginByToken()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // ? Alternative decode Token Manually
            // var splitedAuthHeaders = Request.Headers.Authorization.ToString().Split(" ");
            // var jwtString = splitedAuthHeaders[splitedAuthHeaders.Length - 1];

            // var jwt = _tokenService.ConvertJwtStringToJwtSecurityToken(jwtString);
            // var decoded = _tokenService.DecodeToken(jwt);

            return await _userService.LoginByToken(Convert.ToInt64(userId), Request);
        }
    }
}
