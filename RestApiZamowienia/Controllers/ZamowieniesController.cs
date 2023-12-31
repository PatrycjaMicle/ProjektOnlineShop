﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;
using RestApiZamowienia.Services.Interfaces;

namespace RestApiZamowienia.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ZamowieniesController : ControllerBase
{
    private readonly SklepInternetowyContext _context;
    private readonly IUserContextService _userContextService;

    public ZamowieniesController(SklepInternetowyContext context, IUserContextService userContextService)
    {
        _context = context;
        _userContextService = userContextService;
    }

    // GET: api/Zamowienies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Zamowienie>>> GetZamowienies()
    {
        var userId = _userContextService.GetUserId;

        if (!userId.HasValue) return BadRequest("Invalid user ID format.");

        if (_context.Zamowienies == null) return NotFound();
        return await _context.Zamowienies
             .Where(e => e.IdUzytkownika == userId.Value)
        .ToListAsync();
    }

    // GET: api/Zamowienies/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Zamowienie>> GetZamowienie(int id)
    {
        if (_context.Zamowienies == null) return NotFound();
        var zamowienie = await _context.Zamowienies.FindAsync(id);

        if (zamowienie == null) return NotFound();

        return zamowienie;
    }

    // PUT: api/Zamowienies/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutZamowienie(int id, Zamowienie zamowienie)
    {
        if (id != zamowienie.IdZamowienia) return BadRequest();

        _context.Entry(zamowienie).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ZamowienieExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Zamowienies
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Zamowienie>> PostZamowienie(Zamowienie zamowienie)
    {
        if (_context.ElementKoszykas == null)
            return NotFound();

        var userId = _userContextService.GetUserId;

        var elementyKoszyka = await _context.ElementKoszykas
            .Where(e => e.IdUzytkownika == userId.Value)
            .ToListAsync();
        decimal? suma = 0;

        foreach (var item in elementyKoszyka)
        {
            var towar = await _context.Towars.FindAsync(item.IdTowaru);
            suma += ((decimal)(towar?.Cena ?? 0m) * item.Ilosc);
        }

        if (!userId.HasValue)
            return BadRequest("Invalid user ID format.");

        zamowienie.IdUzytkownika = userId;
        zamowienie.DataZamowienia = DateTime.Now;
        zamowienie.IdMetodyPlatnosci = 1;
        zamowienie.TerminDostawy = DateTime.Now.Add(TimeSpan.FromDays(7));

        if (zamowienie.IdKoduPromocji.HasValue)
        {
            var kodPromocji = await _context.KodPromocjis
                .Where(k => k.IdKoduPromocji == zamowienie.IdKoduPromocji)
                .FirstOrDefaultAsync();

            if (kodPromocji != null)
            {
                var promocja = await _context.Promocjas
                    .Where(p => p.IdPromocji == kodPromocji.IdPromocji)
                    .FirstOrDefaultAsync();

                if (promocja != null)
                {
                    suma -= suma * (promocja.ZnizkaWProcentach / 100);
                }
            }
        }

        zamowienie.Suma = suma;

        if (_context.Zamowienies == null)
            return Problem("Entity set 'SklepInternetowyContext.Zamowienies' is null.");

        _context.Zamowienies.Add(zamowienie);
        await _context.SaveChangesAsync();

        return Ok(zamowienie);
    }

    // DELETE: api/Zamowienies/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteZamowienie(int id)
    {
        if (_context.Zamowienies == null) return NotFound();
        var zamowienie = await _context.Zamowienies.FindAsync(id);
        if (zamowienie == null) return NotFound();

        _context.Zamowienies.Remove(zamowienie);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ZamowienieExists(int id)
    {
        return (_context.Zamowienies?.Any(e => e.IdZamowienia == id)).GetValueOrDefault();
    }
}