using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SklepInternetowy.WWW.Services;

public class UserService 
{
    public string Token { get; set; }
    public int UserId { get; set; } 
    public string? UserRole { get; set; }

    //TODO this shouldn't be hardcoded
    public bool IsAdmin => UserRole == "Admin";

    public bool IsUserSignedIn => UserRole != null;

    public void DecodeJwt()
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(Token) as JwtSecurityToken;

        UserId = int.Parse(jsonToken.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier).Value);
        UserRole = jsonToken.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Role).Value;
    }

    public Task Logout()
    {
        Token = null;
        UserId = 0;
        UserRole = null;
        
        return Task.CompletedTask;
    }
}
