using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Dtos;
using dot_dotnet_test_api.Helpers;
using NuGet.Protocol;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FluentValidation.Results;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using dot_dotnet_test_api.Validators;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using dot_dotnet_test_api.Services.UserService;

namespace dot_dotnet_test_api.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class UserV1Controller(
        SQLServerContext context,
        ILogger<UserV1Controller> logger,
        TokenService tokenService,
        UserService userService
    ) : ControllerBase
    {
        private readonly SQLServerContext _context = context;
        private readonly ILogger<UserV1Controller> _logger = logger;
        private readonly TokenService _tokenService = tokenService;
        private readonly UserService _userService = userService;


        // POST: api/v1/register
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("register")]
        public async Task<ContentResult> Register([FromForm] UserV1RegisterDto userV1RegisterDto)
        {
            var validator = new UserV1RegisterDtoValidator();
            ValidationResult results = validator.Validate(userV1RegisterDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Registration Failed.");

            return await _userService.Register(userV1RegisterDto, Request);
        }

        // POST: api/v1/login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("login")]
        public async Task<ContentResult> Login(UserV1LoginDto userV1LoginDto)
        {
            var validator = new UserV1LoginDtoValidator();
            ValidationResult results = validator.Validate(userV1LoginDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results);

            return await _userService.Login(userV1LoginDto, Request);
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
