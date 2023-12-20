using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;

namespace RestApiZamowienia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriumController : ControllerBase
    {
        private readonly SklepInternetowyContext _context;

        public KategoriumController(SklepInternetowyContext context)
        {
            _context = context;
        }

        // GET: api/Kategorium
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategorium>>> GetKategoria()
        {
          if (_context.Kategoria == null)
          {
              return NotFound();
          }
            return await _context.Kategoria.ToListAsync();
        }

        // GET: api/Kategorium/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategorium>> GetKategorium(int id)
        {
          if (_context.Kategoria == null)
          {
              return NotFound();
          }
            var kategorium = await _context.Kategoria.FindAsync(id);

            if (kategorium == null)
            {
                return NotFound();
            }

            return kategorium;
        }

        // PUT: api/Kategorium/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategorium(int id, Kategorium kategorium)
        {
            if (id != kategorium.IdKategorii)
            {
                return BadRequest();
            }

            _context.Entry(kategorium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoriumExists(id))
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

        // POST: api/Kategorium
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kategorium>> PostKategorium(Kategorium kategorium)
        {
          if (_context.Kategoria == null)
          {
              return Problem("Entity set 'SklepInternetowyContext.Kategoria'  is null.");
          }
            _context.Kategoria.Add(kategorium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKategorium", new { id = kategorium.IdKategorii }, kategorium);
        }

        // DELETE: api/Kategorium/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategorium(int id)
        {
            if (_context.Kategoria == null)
            {
                return NotFound();
            }
            var kategorium = await _context.Kategoria.FindAsync(id);
            if (kategorium == null)
            {
                return NotFound();
            }

            _context.Kategoria.Remove(kategorium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KategoriumExists(int id)
        {
            return (_context.Kategoria?.Any(e => e.IdKategorii == id)).GetValueOrDefault();
        }
    }
}
