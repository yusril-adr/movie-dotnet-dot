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

namespace dot_dotnet_test_api.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class UserV1Controller : ControllerBase
    {
        private readonly SQLServerContext _context;
        private readonly ILogger<UserV1Controller> _logger;
        private IConfiguration _configuration;
        private readonly TokenService _tokenService;

        public UserV1Controller(SQLServerContext context, ILogger<UserV1Controller> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _tokenService = new TokenService(configuration);
        }


        // POST: api/v1/register
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("register")]
        public async Task<ActionResult<UserV1>> Register([FromForm] UserV1RegisterDto userV1RegisterDto)
        {
            try
            {
                var validator = new UserV1RegisterDtoValidator();
                ValidationResult results = validator.Validate(userV1RegisterDto);

                if (!results.IsValid) return ValidationHelper.ValidateResponseError(results);

                var splittedFileNames = userV1RegisterDto.Avatar.FileName.Split(".");
                var fileExtension = splittedFileNames[splittedFileNames.Length - 1];
                var filePath = Path.Combine("./files/images/avatar", Path.GetRandomFileName() + "." + fileExtension);

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
                    var errorField = new ValidationErrorResponseField("Email")
                    {
                        Messages = ["Email is already used."]
                    };
                    var responseSQLException = new ValidationErrorResponse
                    {
                        Errors = [errorField],
                        Message = "Register Failed",
                    };

                    return responseSQLException.GetFormated(statusCode: 409);
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
                return response.GetFormated(statusCode: 201);
            }
            catch (Exception error)
            {
                _logger.LogInformation(error.ToString());
                var response = new Response<object>(
                    errors: ["Internal Server Error"],
                    message: "Register Failed"
                );

                return response.GetFormated(statusCode: 500);
            }
        }

        // POST: api/v1/login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("login")]
        public async Task<ActionResult<UserV1>> Login(UserV1LoginDto userV1LoginDto)
        {
            try
            {
                var validator = new UserV1LoginDtoValidator();
                ValidationResult results = validator.Validate(userV1LoginDto);

                if (!results.IsValid) return ValidationHelper.ValidateResponseError(results);

                var foundedUser = await _context.Users.Where(user => user.Email == userV1LoginDto.Email).Select(user => user).FirstOrDefaultAsync();

                if (foundedUser == null)
                {
                    return new Response<object>(
                        errors: ["Email or Password Didn't match."],
                        message: "Login Failed"
                    ).GetFormated(statusCode: 401);
                }

                var isPasswordValid = PasswordHasher.VerifyPassword(userV1LoginDto.Password, foundedUser.Password);
                if (!isPasswordValid)
                {
                    return new Response<object>(
                        errors: ["Email or Password Didn't match."],
                        message: "Login Failed"
                    ).GetFormated(statusCode: 401);
                }

                var baseUri = $"{Request.Scheme}://{Request.Host}";
                var splitedFileName = foundedUser.Avatar.Split('/');
                var fileName = splitedFileName[splitedFileName.Length - 1];
                var deployedFilePath = $"{baseUri}/images/avatar/{fileName}";

                return new Response<object>(
                    data: new
                    {
                        email = foundedUser.Email,
                        name= foundedUser.Name,
                        avatar = deployedFilePath,
                        _token = _tokenService.CreateToken(foundedUser.Id),
                    },
                    message: "Login Success"
                ).GetFormated();
            }
            catch (Exception error)
            {
                _logger.LogInformation(error.ToString());
                return new Response<object>(
                    errors: ["Internal Server Error"],
                    message: "Login Failed"
                ).GetFormated(statusCode: 500);
            }
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
