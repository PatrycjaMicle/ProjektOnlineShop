using RestApiZamowienia.Dto;

namespace RestApiZamowienia.Services.Interfaces
{
    public interface IAccountService
    {
        Task RegisterUser(RegisterUserDto registerDto);
        Task<string> GenerateJwt(LoginDto dto);
        Task DeleteUser(string email);
    }
}
