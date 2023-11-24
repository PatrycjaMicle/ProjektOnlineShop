using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;

namespace RestApiZamowienia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UzytkownikController : ControllerBase
    {
        private readonly SklepInternetowyContext _context;
        public UzytkownikController(SklepInternetowyContext context)=>_context=context;

        [HttpGet]
        public async Task<IEnumerable<Uzytkownik>> Get()
        => await _context.Uzytkowniks.ToListAsync();
    
    }
}
