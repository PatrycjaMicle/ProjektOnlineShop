using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;

namespace RestApiZamowienia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TowarController : ControllerBase
    {
        private readonly SklepInternetowyContext _context;

        public TowarController(SklepInternetowyContext context)
        {
            _context = context;
        }

        // GET: api/Towar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Towar>>> GetTowars()
        {
          if (_context.Towars == null)
          {
              return NotFound();
          }
            return await _context.Towars.ToListAsync();
        }

        // GET: api/Towar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Towar>> GetTowar(int id)
        {
          if (_context.Towars == null)
          {
              return NotFound();
          }
            var towar = await _context.Towars.FindAsync(id);

            if (towar == null)
            {
                return NotFound();
            }

            return towar;
        }

        // PUT: api/Towar/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTowar(int id, Towar towar)
        {
            if (id != towar.IdTowaru)
            {
                return BadRequest();
            }

            _context.Entry(towar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TowarExists(id))
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

        // POST: api/Towar
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Towar>> PostTowar(Towar towar)
        {
          if (_context.Towars == null)
          {
              return Problem("Entity set 'SklepInternetowyContext.Towars'  is null.");
          }
            _context.Towars.Add(towar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTowar", new { id = towar.IdTowaru }, towar);
        }

        // DELETE: api/Towar/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTowar(int id)
        {
            if (_context.Towars == null)
            {
                return NotFound();
            }
            var towar = await _context.Towars.FindAsync(id);
            if (towar == null)
            {
                return NotFound();
            }

            _context.Towars.Remove(towar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TowarExists(int id)
        {
            return (_context.Towars?.Any(e => e.IdTowaru == id)).GetValueOrDefault();
        }
    }
}
