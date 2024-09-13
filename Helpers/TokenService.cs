using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace dot_dotnet_test_api.Helpers;

public class DecodedToken
{
  public long? id { get; set; }
}

public class TokenService
{
  private IConfiguration _configuration;

  public TokenService(IConfiguration configuration)
  {
    _configuration = configuration;
  }


  public string CreateToken(long id)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity([
        new Claim(ClaimTypes.NameIdentifier, id.ToString()),
        // TODO Add if you want to save another info
        // new Claim(ClaimTypes.Role, user.Role.ToString()),
      ]),
      Expires = DateTime.UtcNow.AddHours(1),
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
      Issuer = _configuration["Jwt:Issuer"],
      Audience = _configuration["Jwt:Audience"]
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);

  }

  public JwtSecurityToken ConvertJwtStringToJwtSecurityToken(string? jwt)
  {

    var handler = new JwtSecurityTokenHandler();
    var token = handler.ReadJwtToken(jwt);

    return token;
  }


  public DecodedToken DecodeToken(JwtSecurityToken token)
  {
    var keyId = token.Header.Kid;
    var audience = token.Audiences.ToList();
    var claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToList();
    return new DecodedToken()
    {
      id = Convert.ToInt64(token.Payload[ClaimTypes.NameIdentifier] as string),
    };
  }
}
