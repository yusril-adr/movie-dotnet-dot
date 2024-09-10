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

namespace dot_dotnet_test_api.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class UserV1Controller : ControllerBase
    {
        private readonly SQLServerContext _context;
        private readonly ILogger<UserV1Controller> _logger;
        private readonly TokenService _tokenService;

        public UserV1Controller(SQLServerContext context, ILogger<UserV1Controller> logger, TokenService tokenService)
        {
            _context = context;
            _logger = logger;
            _tokenService = tokenService;
        }


        // POST: api/v1/register
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("register")]
        public async Task<ActionResult<UserV1>> Register([FromForm] UserV1RegisterDto userV1RegisterDto)
        {

            var validator = new UserV1RegisterDtoValidator();
            ValidationResult results = validator.Validate(userV1RegisterDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results, "Registration Failed.");

            var splittedFileNames = userV1RegisterDto.Avatar.FileName.Split(".");
            var fileExtension = splittedFileNames[splittedFileNames.Length - 1];
            var filePath = Path.Combine("./files/images/avatar", Path.GetRandomFileName() + "-user" + "." + fileExtension);

            using (var stream = System.IO.File.Create(filePath))
            {
                await userV1RegisterDto.Avatar.CopyToAsync(stream);
            }

            var savedSplitedFileNames = filePath.Split('/');
            var savedFileName = savedSplitedFileNames[savedSplitedFileNames.Length - 1];
            var createdUser = new UserV1()
            {
                Name = userV1RegisterDto.Name,
                Email = userV1RegisterDto.Email,
                Avatar = filePath,
                Password = PasswordHasher.HashPassword(userV1RegisterDto.Password),
            };

            try
            {
                _context.Users.Add(createdUser);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException error)
            {
                var responseSQLException = new Response<object>(
                    error: "Email already Used",
                    message: "Register Failed"
                );

                return responseSQLException.GetFormated(statusCode: StatusCodes.Status400BadRequest);
            }

            var baseUri = $"{Request.Scheme}://{Request.Host}";
            var deployedFilePath = $"{baseUri}/images/avatar/{savedFileName}";
            var response = new Response<object>(
                data: new
                {
                    id = createdUser.Id,
                    email = createdUser.Email,
                    name = createdUser.Name,
                    avatar = deployedFilePath,
                },
                message: "Register Success"
            );
            return response.GetFormated(statusCode: StatusCodes.Status201Created);
        }

        // POST: api/v1/login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("login")]
        public async Task<ActionResult<UserV1>> Login(UserV1LoginDto userV1LoginDto)
        {
            var validator = new UserV1LoginDtoValidator();
            ValidationResult results = validator.Validate(userV1LoginDto);

            if (!results.IsValid) return ValidationHelper.ValidateResponseError(results);

            var foundedUser = await _context.Users.Where(user => user.Email == userV1LoginDto.Email).Select(user => user).FirstOrDefaultAsync();

            if (foundedUser == null)
            {
                return new Response<object>(
                    error: "Email or Password Didn't match.",
                    message: "Login Failed"
                ).GetFormated(statusCode: StatusCodes.Status400BadRequest);
            }

            var isPasswordValid = PasswordHasher.VerifyPassword(userV1LoginDto.Password, foundedUser.Password);
            if (!isPasswordValid)
            {
                return new Response<object>(
                    error: "Email or Password Didn't match.",
                    message: "Login Failed"
                ).GetFormated(statusCode: StatusCodes.Status400BadRequest);
            }

            var baseUri = $"{Request.Scheme}://{Request.Host}";
            var splitedFileName = foundedUser.Avatar.Split('/');
            var fileName = splitedFileName[splitedFileName.Length - 1];
            var deployedFilePath = $"{baseUri}/images/avatar/{fileName}";

            return new Response<object>(
                data: new
                {
                    email = foundedUser.Email,
                    name = foundedUser.Name,
                    avatar = deployedFilePath,
                    _token = _tokenService.CreateToken(foundedUser.Id),
                },
                message: "Login Success"
            ).GetFormated();

        }

        [HttpPost("login/token")]
        [Authorize]
        public async Task<ActionResult<UserV1>> LoginByToken()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // var splitedAuthHeaders = Request.Headers.Authorization.ToString().Split(" ");
            // var jwtString = splitedAuthHeaders[splitedAuthHeaders.Length - 1];

            // var jwt = _tokenService.ConvertJwtStringToJwtSecurityToken(jwtString);
            // var decoded = _tokenService.DecodeToken(jwt);

            var user = await _context.Users.FindAsync(Convert.ToInt64(userId));

            if (user == null)
            {
                throw new UnauthorizedAccessException("User Not Found.");
            }

            var baseUri = $"{Request.Scheme}://{Request.Host}";
            var splitedFileName = user.Avatar.Split('/');
            var fileName = splitedFileName[splitedFileName.Length - 1];
            var deployedFilePath = $"{baseUri}/images/avatar/{fileName}";

            return new Response<object>(
                data: new
                {
                    email = user.Email,
                    name = user.Name,
                    avatar = deployedFilePath,
                },
                message: "Login Success"
            ).GetFormated();
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        // public ValidationErrorResponse FormatValidationErrors(ModelStateDictionary modelState, string message)
        // {
        //     var errorResponse = new ValidationErrorResponse
        //     {
        //         Message = message
        //     };

        //     foreach (var entry in modelState)
        //     {
        //         if (entry.Value.Errors.Any())
        //         {
        //             var validationError = new ValidationError
        //             {
        //                 Property = entry.Key.ToLower() // Use lowercase for property names
        //             };

        //             foreach (var error in entry.Value.Errors)
        //             {
        //                 validationError.Messages.Add(error.ErrorMessage);
        //             }

        //             errorResponse.Errors.Add(validationError);
        //         }
        //     }

        //     return errorResponse;
        // }

    }
}
