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
    public class AdresController : ControllerBase
    {
        private readonly SklepInternetowyContext _context;

        public AdresController(SklepInternetowyContext context)
        {
            _context = context;
        }

        // GET: api/Adres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adre>>> GetAdres()
        {
          if (_context.Adres == null)
          {
              return NotFound();
          }
            return await _context.Adres.ToListAsync();
        }

        // GET: api/Adres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adre>> GetAdre(int id)
        {
          if (_context.Adres == null)
          {
              return NotFound();
          }
            var adre = await _context.Adres.FindAsync(id);

            if (adre == null)
            {
                return NotFound();
            }

            return adre;
        }

        // PUT: api/Adres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdre(int id, Adre adre)
        {
            if (id != adre.IdAdresu)
            {
                return BadRequest();
            }

            _context.Entry(adre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdreExists(id))
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

        // POST: api/Adres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adre>> PostAdre(Adre adre)
        {
          if (_context.Adres == null)
          {
              return Problem("Entity set 'SklepInternetowyContext.Adres'  is null.");
          }
            _context.Adres.Add(adre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdre", new { id = adre.IdAdresu }, adre);
        }

        // DELETE: api/Adres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdre(int id)
        {
            if (_context.Adres == null)
            {
                return NotFound();
            }
            var adre = await _context.Adres.FindAsync(id);
            if (adre == null)
            {
                return NotFound();
            }

            _context.Adres.Remove(adre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdreExists(int id)
        {
            return (_context.Adres?.Any(e => e.IdAdresu == id)).GetValueOrDefault();
        }
    }
}
