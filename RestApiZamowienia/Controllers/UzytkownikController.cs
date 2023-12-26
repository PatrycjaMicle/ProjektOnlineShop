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

        public UzytkownikController(SklepInternetowyContext context)
        {
            _context = context;
        }

        // GET: api/Uzytkownik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uzytkownik>>> GetUzytkowniks()
        {
          if (_context.Uzytkowniks == null)
          {
              return NotFound();
          }
            return await _context.Uzytkowniks.ToListAsync();
        }

        // GET: api/Uzytkownik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uzytkownik>> GetUzytkownik(int id)
        {
          if (_context.Uzytkowniks == null)
          {
              return NotFound();
          }
            var uzytkownik = await _context.Uzytkowniks.FindAsync(id);

            if (uzytkownik == null)
            {
                return NotFound();
            }

            return uzytkownik;
        }

        // PUT: api/Uzytkownik/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUzytkownik(int id, Uzytkownik uzytkownik)
        {
            if (id != uzytkownik.IdUzytkownika)
            {
                return BadRequest();
            }

            _context.Entry(uzytkownik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UzytkownikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Uzytkownik
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Uzytkownik>> PostUzytkownik(Uzytkownik uzytkownik)
        {
          if (_context.Uzytkowniks == null)
          {
              return Problem("Entity set 'SklepInternetowyContext.Uzytkowniks'  is null.");
          }
            _context.Uzytkowniks.Add(uzytkownik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUzytkownik", new { id = uzytkownik.IdUzytkownika }, uzytkownik);
        }

        // DELETE: api/Uzytkownik/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUzytkownik(int id)
        {
            if (_context.Uzytkowniks == null)
            {
                return NotFound();
            }
            var uzytkownik = await _context.Uzytkowniks.FindAsync(id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            _context.Uzytkowniks.Remove(uzytkownik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UzytkownikExists(int id)
        {
            return (_context.Uzytkowniks?.Any(e => e.IdUzytkownika == id)).GetValueOrDefault();
        }
    }
}
