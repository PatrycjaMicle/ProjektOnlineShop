﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiZamowienia.Dto;
using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;

namespace RestApiZamowienia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KodPromocjisController : ControllerBase
    {
        private readonly SklepInternetowyContext _context;

        public KodPromocjisController(SklepInternetowyContext context)
        {
            _context = context;
        }

        [HttpGet("GetZnizka")]
        public async Task<ActionResult<KodPromocjiResponse>> GetZnizka(string? kodInput)
        {
            if (string.IsNullOrEmpty(kodInput))
            {
                return Ok(new KodPromocjiResponse { Znizka = 0, IdKoduPromocji = 0 });
            }

            var kod = await _context.Kods
                .Where(a => a.Nazwa == kodInput)
                .FirstOrDefaultAsync();

            if (kod == null)
            {
                return Ok(new KodPromocjiResponse { Znizka = 0, IdKoduPromocji = 0 });
            }

            var kodPromocji = await _context.KodPromocjis
                .Where(a => a.IdKodu == kod.IdKodu)
                .FirstOrDefaultAsync();

            if (kodPromocji == null)
            {
                return Ok(new KodPromocjiResponse { Znizka = 0, IdKoduPromocji = 0 });
            }

            var promocja = await _context.Promocjas
                .Where(a => a.IdPromocji == kodPromocji.IdPromocji)
                .FirstOrDefaultAsync();

            if (promocja == null)
            {
                return Ok(new KodPromocjiResponse { Znizka = 0, IdKoduPromocji = 0 });
            }

            var znizka = promocja.ZnizkaWProcentach;

            if (znizka == 0)
            {
                return Ok(new KodPromocjiResponse { Znizka = 0, IdKoduPromocji = 0 });
            }

            var response = new KodPromocjiResponse { Znizka = znizka, IdKoduPromocji = kodPromocji.IdKoduPromocji };
            return Ok(response);
        }

        // GET: api/KodPromocjis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KodPromocji>>> GetKodPromocjis()
        {
          if (_context.KodPromocjis == null)
          {
              return NotFound();
          }
            return await _context.KodPromocjis.ToListAsync();
        }

        // GET: api/KodPromocjis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KodPromocji>> GetKodPromocji(int id)
        {
          if (_context.KodPromocjis == null)
          {
              return NotFound();
          }
            var kodPromocji = await _context.KodPromocjis.FindAsync(id);

            if (kodPromocji == null)
            {
                return NotFound();
            }

            return kodPromocji;
        }

        // PUT: api/KodPromocjis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKodPromocji(int id, KodPromocji kodPromocji)
        {
            if (id != kodPromocji.IdKoduPromocji)
            {
                return BadRequest();
            }

            _context.Entry(kodPromocji).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KodPromocjiExists(id))
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

        // POST: api/KodPromocjis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KodPromocji>> PostKodPromocji(KodPromocji kodPromocji)
        {
          if (_context.KodPromocjis == null)
          {
              return Problem("Entity set 'SklepInternetowyContext.KodPromocjis'  is null.");
          }
            _context.KodPromocjis.Add(kodPromocji);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKodPromocji", new { id = kodPromocji.IdKoduPromocji }, kodPromocji);
        }

        // DELETE: api/KodPromocjis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKodPromocji(int id)
        {
            if (_context.KodPromocjis == null)
            {
                return NotFound();
            }
            var kodPromocji = await _context.KodPromocjis.FindAsync(id);
            if (kodPromocji == null)
            {
                return NotFound();
            }

            _context.KodPromocjis.Remove(kodPromocji);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KodPromocjiExists(int id)
        {
            return (_context.KodPromocjis?.Any(e => e.IdKoduPromocji == id)).GetValueOrDefault();
        }
    }
}
