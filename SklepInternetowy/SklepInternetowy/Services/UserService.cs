using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace SklepInternetowy.Services
{
    public class UserService
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string UserRole { get; set; }

        public void DecodeJwt()
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(Token) as JwtSecurityToken;

            UserId = int.Parse(jsonToken.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier).Value);
           // UserRole = jsonToken.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Role).Value;
        }
    }
}