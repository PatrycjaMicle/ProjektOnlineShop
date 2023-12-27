using MessagePack;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestApiZamowienia.Services
{
    public class JwtService
    {
        public static string GetUserFromToken(string token)
        {

            // ClaimTypes.NameIdentifier
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            // Assuming jwtSecurityToken is not null
            var userIdClaim = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                return userIdClaim.Value;
            }

            return string.Empty;
        }
    }
}
