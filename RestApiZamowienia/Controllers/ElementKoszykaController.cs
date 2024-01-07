using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;
using RestApiZamowienia.Services.Interfaces;

namespace RestApiZamowienia.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ElementKoszykaController : ControllerBase
{
    private readonly SklepInternetowyContext _context;
    private readonly IUserContextService _userContextService;

    public ElementKoszykaController(SklepInternetowyContext context, IUserContextService userContextService)
    {
        _context = context;
        _userContextService = userContextService;
    }

    // GET: api/ElementKoszyka
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ElementKoszyka>>> GetElementKoszykas()
    {
        var userId = _userContextService.GetUserId;

        if (!userId.HasValue) return BadRequest("Invalid user ID format.");

        if (_context.ElementKoszykas == null) return NotFound();
        return await _context.ElementKoszykas
        .Where(e => e.IdUzytkownika == userId.Value)
        .ToListAsync();
    }

    // GET: api/ElementKoszyka/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ElementKoszyka>> GetElementKoszyka(int id)
    {
        if (_context.ElementKoszykas == null) return NotFound();
        var elementKoszyka = await _context.ElementKoszykas.FindAsync(id);

        if (elementKoszyka == null) return NotFound();

        return elementKoszyka;
    }

    // PUT: api/ElementKoszyka/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutElementKoszyka(int id, ElementKoszyka elementKoszyka)
    {
        if (id != elementKoszyka.IdElementuKoszyka) return BadRequest();

        _context.Entry(elementKoszyka).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ElementKoszykaExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/ElementKoszyka
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ElementKoszyka>> PostElementKoszyka(ElementKoszyka elementKoszyka)
    {
        if (_context.ElementKoszykas == null) return NotFound();

        var userId = _userContextService.GetUserId;

        if (!userId.HasValue) return BadRequest("Invalid user ID format.");

        var existingElementKoszyka = await _context.ElementKoszykas
            .FirstOrDefaultAsync(e => e.IdTowaru == elementKoszyka.IdTowaru && e.IdUzytkownika == userId);

        if (existingElementKoszyka != null && existingElementKoszyka.IdTowaru != null)
        {
            existingElementKoszyka.Ilosc += 1;
            elementKoszyka.DataUtworzenia = DateTime.Now;

            _context.Entry(existingElementKoszyka).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(existingElementKoszyka);
        }
        else
        {
            elementKoszyka.IdUzytkownika = userId;
            elementKoszyka.Ilosc = 1;
            elementKoszyka.DataUtworzenia = DateTime.Now;

            _context.ElementKoszykas.Add(elementKoszyka);
            await _context.SaveChangesAsync();

            return Ok(elementKoszyka);
        }
    }

    // DELETE: api/ElementKoszyka/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteElementKoszyka(int id)
    {
        if (_context.ElementKoszykas == null) return NotFound();
        var elementKoszyka = await _context.ElementKoszykas.FindAsync(id);
        if (elementKoszyka == null) return NotFound();

        _context.ElementKoszykas.Remove(elementKoszyka);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ElementKoszykaExists(int id)
    {
        return (_context.ElementKoszykas?.Any(e => e.IdElementuKoszyka == id)).GetValueOrDefault();
    }
}