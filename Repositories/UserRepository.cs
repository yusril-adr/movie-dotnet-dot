using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Permissions;
using System.Text;
using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using NuGet.Protocol;

namespace dot_dotnet_test_api.Repositories;

public class UserRepository(IConfiguration configuration, SQLServerContext context, ILogger<UserRepository> logger)
{
  private IConfiguration _configuration = configuration;

  private readonly SQLServerContext _context = context;
  private readonly ILogger<UserRepository> _logger = logger;

  public async Task<User> Create(User user) {
    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return user;
  }

  public async Task<User?> FindByEmail(string email) {
    var foundedUser = await _context.Users
      .Where(user => user.Email == email)
      .Select(user => user)
      .FirstOrDefaultAsync();
    return foundedUser;
  }

  public async Task<User?> FindById(long userId) {
    var foundedUser = await _context.Users.FindAsync(userId);
;
    return foundedUser;
  }
}