using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApiZamowienia.Dto;
using RestApiZamowienia.Services.Interfaces;

namespace RestApiZamowienia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontoController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public KontoController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(RegisterUserDto dto)
        {
            await _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto dto)
        {
            var jwt = await _accountService.GenerateJwt(dto);
            return Ok(jwt);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string email)
        {
            await _accountService.DeleteUser(email);
            return NoContent();
        }
    }
}
