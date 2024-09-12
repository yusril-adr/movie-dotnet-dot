using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Dtos;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Repositories;
using dot_dotnet_test_api.Services.UserResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_dotnet_test_api.Services.UserService;

public class UserService(
  IConfiguration configuration,
  UserRepository userRepository,
  TokenService tokenService,
  ILogger<UserService> logger
)
{
  private IConfiguration _configuration = configuration;

  private readonly TokenService _tokenService = tokenService;

  private readonly UserRepository _userRepository = userRepository;
  private readonly ILogger<UserService> _logger = logger;


  private static async Task<AvatarFileResult> CopyAvatarFile(IFormFile avatar)
  {
    var splittedFileNames = avatar.FileName.Split(".");
    var fileExtension = splittedFileNames[^1];
    var filePath = Path.Combine("./files/images/avatar", $"{Path.GetRandomFileName()}-user.{fileExtension}");

    using (var stream = File.Create(filePath))
    {
      await avatar.CopyToAsync(stream);
    }

    var savedSplitedFileNames = filePath.Split('/');
    var savedFileName = savedSplitedFileNames[savedSplitedFileNames.Length - 1];

    return new AvatarFileResult
    {
      FilePath = filePath,
      SavedFileName = savedFileName
    };
  }

  private static string GetDeployedAvatarPath(string filePath, HttpRequest request)
  {
    var baseUri = $"{request.Scheme}://{request.Host}";
    var splitedFileName = filePath.Split('/');
    var fileName = splitedFileName[^1];
    var deployedFilePath = $"{baseUri}/images/avatar/{fileName}";

    return deployedFilePath;
  }

  public async Task<ContentResult> Register(UserV1RegisterDto userV1RegisterDto, HttpRequest request)
  {
    var avatarFileResult = await CopyAvatarFile(userV1RegisterDto.Avatar);
    var deployedFilePath = GetDeployedAvatarPath(avatarFileResult.FilePath, request);

    var createdUser = new User()
    {
      Name = userV1RegisterDto.Name,
      Email = userV1RegisterDto.Email,
      Avatar = avatarFileResult.FilePath,
      Password = PasswordHasher.HashPassword(userV1RegisterDto.Password),
    };

    try
    {
      await _userRepository.Create(createdUser);
    }
    catch (DbUpdateException)
    {
      var responseSQLException = new Response<object>(
        error: "Email already Used.",
        message: "Register Failed"
      );

      return responseSQLException.GetFormated(statusCode: StatusCodes.Status400BadRequest);
    }


    var response = new Response<RegisterResult>(
        data: new RegisterResult
        {
          Id = createdUser.Id,
          Email = createdUser.Email,
          Name = createdUser.Name,
          Avatar = deployedFilePath,
        },
        message: "Register Success"
    );
    return response.GetFormated(statusCode: StatusCodes.Status201Created);
  }

  public async Task<ContentResult> Login(UserV1LoginDto userV1LoginDto, HttpRequest request)
  {
    var foundedUser = await _userRepository.FindByEmail(userV1LoginDto.Email);
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

    var deployedFilePath = GetDeployedAvatarPath(foundedUser.Avatar, request);

    return new Response<LoginResult>(
        data: new LoginResult
        {
          Id = foundedUser.Id,
          Email = foundedUser.Email,
          Name = foundedUser.Name,
          Avatar = deployedFilePath,
          Token = _tokenService.CreateToken(foundedUser.Id),
        },
        message: "Login Success"
    ).GetFormated();
  }

  public async Task<ContentResult> LoginByToken(long userId, HttpRequest request)
  {
    var foundedUser = await _userRepository.FindById(userId);
    if (foundedUser == null)
    {
      return new Response<object>(
          error: "Token invalid or expired.",
          message: "Login By Token Failed"
      ).GetFormated(statusCode: StatusCodes.Status401Unauthorized);
    }

    var deployedFilePath = GetDeployedAvatarPath(foundedUser.Avatar, request);

    return new Response<LoginByIdResult>(
        data: new LoginByIdResult
        {
          Id = foundedUser.Id,
          Email = foundedUser.Email,
          Name = foundedUser.Name,
          Avatar = deployedFilePath,
        },
        message: "Login By Token Success"
    ).GetFormated();
  }
}
