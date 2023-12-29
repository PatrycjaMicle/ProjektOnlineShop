using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;

namespace RestApiZamowienia.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MetodaPlatnoscisController : ControllerBase
{
    private readonly SklepInternetowyContext _context;

    public MetodaPlatnoscisController(SklepInternetowyContext context)
    {
        _context = context;
    }

    // GET: api/MetodaPlatnoscis
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MetodaPlatnosci>>> GetMetodaPlatnoscis()
    {
        if (_context.MetodaPlatnoscis == null) return NotFound();
        return await _context.MetodaPlatnoscis.ToListAsync();
    }

    // GET: api/MetodaPlatnoscis/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MetodaPlatnosci>> GetMetodaPlatnosci(int id)
    {
        if (_context.MetodaPlatnoscis == null) return NotFound();
        var metodaPlatnosci = await _context.MetodaPlatnoscis.FindAsync(id);

        if (metodaPlatnosci == null) return NotFound();

        return metodaPlatnosci;
    }

    // PUT: api/MetodaPlatnoscis/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMetodaPlatnosci(int id, MetodaPlatnosci metodaPlatnosci)
    {
        if (id != metodaPlatnosci.IdMetodyPlatnosci) return BadRequest();

        _context.Entry(metodaPlatnosci).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MetodaPlatnosciExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/MetodaPlatnoscis
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<MetodaPlatnosci>> PostMetodaPlatnosci(MetodaPlatnosci metodaPlatnosci)
    {
        if (_context.MetodaPlatnoscis == null)
            return Problem("Entity set 'SklepInternetowyContext.MetodaPlatnoscis'  is null.");
        _context.MetodaPlatnoscis.Add(metodaPlatnosci);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMetodaPlatnosci", new { id = metodaPlatnosci.IdMetodyPlatnosci }, metodaPlatnosci);
    }

    // DELETE: api/MetodaPlatnoscis/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMetodaPlatnosci(int id)
    {
        if (_context.MetodaPlatnoscis == null) return NotFound();
        var metodaPlatnosci = await _context.MetodaPlatnoscis.FindAsync(id);
        if (metodaPlatnosci == null) return NotFound();

        _context.MetodaPlatnoscis.Remove(metodaPlatnosci);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MetodaPlatnosciExists(int id)
    {
        return (_context.MetodaPlatnoscis?.Any(e => e.IdMetodyPlatnosci == id)).GetValueOrDefault();
    }
}