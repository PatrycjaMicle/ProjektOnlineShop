using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;

namespace RestApiZamowienia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesjaKoszykaController : ControllerBase
    {
        private readonly SklepInternetowyContext _context;

        public SesjaKoszykaController(SklepInternetowyContext context)
        {
            _context = context;
        }

        // GET: api/SesjaKoszyka
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SesjaKoszyka>>> GetSesjaKoszykas()
        {
          if (_context.SesjaKoszykas == null)
          {
              return NotFound();
          }
            return await _context.SesjaKoszykas.ToListAsync();
        }

        // GET: api/SesjaKoszyka/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SesjaKoszyka>> GetSesjaKoszyka(int id)
        {
          if (_context.SesjaKoszykas == null)
          {
              return NotFound();
          }
            var sesjaKoszyka = await _context.SesjaKoszykas.FindAsync(id);

            if (sesjaKoszyka == null)
            {
                return NotFound();
            }

            return sesjaKoszyka;
        }

        // PUT: api/SesjaKoszyka/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSesjaKoszyka(int id, SesjaKoszyka sesjaKoszyka)
        {
            if (id != sesjaKoszyka.IdSesjiKoszyka)
            {
                return BadRequest();
            }

            _context.Entry(sesjaKoszyka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SesjaKoszykaExists(id))
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

        // POST: api/SesjaKoszyka
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SesjaKoszyka>> PostSesjaKoszyka(SesjaKoszyka sesjaKoszyka)
        {
          if (_context.SesjaKoszykas == null)
          {
              return Problem("Entity set 'SklepInternetowyContext.SesjaKoszykas'  is null.");
          }
            _context.SesjaKoszykas.Add(sesjaKoszyka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSesjaKoszyka", new { id = sesjaKoszyka.IdSesjiKoszyka }, sesjaKoszyka);
        }

        // DELETE: api/SesjaKoszyka/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesjaKoszyka(int id)
        {
            if (_context.SesjaKoszykas == null)
            {
                return NotFound();
            }
            var sesjaKoszyka = await _context.SesjaKoszykas.FindAsync(id);
            if (sesjaKoszyka == null)
            {
                return NotFound();
            }

            _context.SesjaKoszykas.Remove(sesjaKoszyka);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SesjaKoszykaExists(int id)
        {
            return (_context.SesjaKoszykas?.Any(e => e.IdSesjiKoszyka == id)).GetValueOrDefault();
        }
    }
}
