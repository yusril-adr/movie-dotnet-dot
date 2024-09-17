using dot_dotnet_test_api.API.Version1.Dtos;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_dotnet_test_api.API.Version1.Services;

public class UserService(
  IConfiguration configuration,
  UserRepository userRepository,
  TokenHelper tokenHelper,
  FileHelper fileHelper,
  ILogger<UserService> logger
)
{
  private readonly IConfiguration _configuration = configuration;
  private readonly UserRepository _userRepository = userRepository;
  private readonly TokenHelper _tokenHelper = tokenHelper;
  private readonly FileHelper _fileHelper = fileHelper;
  private readonly ILogger<UserService> _logger = logger;

  private static string GetDeployedAvatarPath(string filePath, HttpRequest request)
  {
    var baseUri = $"{request.Scheme}://{request.Host}";
    var splitedFileName = filePath.Split('/');
    var fileName = splitedFileName[^1];
    var deployedFilePath = $"{baseUri}/images/avatar/{fileName}";

    return deployedFilePath;
  }

  public async Task<ContentResult> Register(UserRegisterDto userRegisterDto, HttpRequest request)
  {
    var avatarFileResult = await FileHelper.CopyFile(
      file: userRegisterDto.Avatar,
      path: "./files/images/avatar",
      prefix: "user"
    );
    var deployedFilePath = GetDeployedAvatarPath(avatarFileResult.FilePath, request);

    var createdUser = new User()
    {
      Name = userRegisterDto.Name,
      Email = userRegisterDto.Email,
      Avatar = avatarFileResult.FilePath,
      Password = PasswordHasher.HashPassword(userRegisterDto.Password),
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
        data: RegisterResult.MapJson(createdUser, deployedFilePath),
        message: "Register Success"
    );
    return response.GetFormated(statusCode: StatusCodes.Status201Created);
  }

  public async Task<ContentResult> Login(UserLoginDto userLoginDto, HttpRequest request)
  {
    var foundedUser = await _userRepository.FindByEmail(userLoginDto.Email);
    if (foundedUser == null)
    {
      return new Response<object>(
          error: "Email or Password Didn't match.",
          message: "Login Failed"
      ).GetFormated(statusCode: StatusCodes.Status400BadRequest);
    }

    var isPasswordValid = PasswordHasher.VerifyPassword(userLoginDto.Password, foundedUser.Password);
    if (!isPasswordValid)
    {
      return new Response<object>(
          error: "Email or Password Didn't match.",
          message: "Login Failed"
      ).GetFormated(statusCode: StatusCodes.Status400BadRequest);
    }

    var deployedFilePath = GetDeployedAvatarPath(foundedUser.Avatar, request);

    return new Response<LoginResult>(
        data: LoginResult.MapJson(foundedUser, deployedFilePath, _tokenHelper.CreateToken(foundedUser.Id)),
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
        data: LoginByIdResult.MapJson(foundedUser, deployedFilePath),
        message: "Login By Token Success"
    ).GetFormated();
  }
}
