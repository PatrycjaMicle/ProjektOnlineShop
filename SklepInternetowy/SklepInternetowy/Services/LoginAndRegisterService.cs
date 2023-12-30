using System.Net.Http;
using System.Threading.Tasks;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.Services
{
    public class LoginAndRegisterService
    {
        private readonly SklepInternetowyService _sklepInternetowyService;

        public LoginAndRegisterService()
        {
            _sklepInternetowyService = new SklepInternetowyService("http://localhost:5219/", new HttpClient());
        }

        public async Task Register(RegisterUserDto dto)
        {
            await _sklepInternetowyService.RegisterAsync(dto);
        }

        public async Task<JwtStorage> Login(LoginDto dto)
        {
            return await _sklepInternetowyService.LoginAsync(dto);
        }
    }
}