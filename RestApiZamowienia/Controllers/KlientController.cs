using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;

namespace RestApiZamowienia.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KlientController : ControllerBase
{
    private readonly SklepInternetowyContext _context;

    public KlientController(SklepInternetowyContext context)
    {
        _context = context;
    }

    // GET: api/Klient
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Klient>>> GetKlients()
    {
        if (_context.Klients == null) return NotFound();
        return await _context.Klients.ToListAsync();
    }

    // GET: api/Klient/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Klient>> GetKlient(int id)
    {
        if (_context.Klients == null) return NotFound();
        var klient = await _context.Klients.FindAsync(id);

        if (klient == null) return NotFound();

        return klient;
    }

    // PUT: api/Klient/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutKlient(int id, Klient klient)
    {
        if (id != klient.IdKlienta) return BadRequest();

        _context.Entry(klient).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!KlientExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Klient
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Klient>> PostKlient(Klient klient)
    {
        if (_context.Klients == null) return Problem("Entity set 'SklepInternetowyContext.Klients'  is null.");
        _context.Klients.Add(klient);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetKlient", new { id = klient.IdKlienta }, klient);
    }

    // DELETE: api/Klient/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteKlient(int id)
    {
        if (_context.Klients == null) return NotFound();
        var klient = await _context.Klients.FindAsync(id);
        if (klient == null) return NotFound();

        _context.Klients.Remove(klient);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool KlientExists(int id)
    {
        return (_context.Klients?.Any(e => e.IdKlienta == id)).GetValueOrDefault();
    }
}