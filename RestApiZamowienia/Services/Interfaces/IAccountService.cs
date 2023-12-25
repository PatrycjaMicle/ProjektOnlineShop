using RestApiZamowienia.Dto;
using RestApiZamowienia.Models;

namespace RestApiZamowienia.Services.Interfaces
{
    public interface IAccountService
    {
        Task RegisterUser(RegisterUserDto registerDto);
        Task<string> GenerateJwt(LoginDto dto);
        Task DeleteUser(string email);
    }
}
