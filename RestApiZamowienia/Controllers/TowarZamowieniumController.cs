﻿using System;
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
    public class TowarZamowieniumController : ControllerBase
    {
        private readonly SklepInternetowyContext _context;

        public TowarZamowieniumController(SklepInternetowyContext context)
        {
            _context = context;
        }

        // GET: api/TowarZamowienium
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TowarZamowienium>>> GetTowarZamowienia()
        {
          if (_context.TowarZamowienia == null)
          {
              return NotFound();
          }
            return await _context.TowarZamowienia.ToListAsync();
        }

        // GET: api/TowarZamowienium/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TowarZamowienium>> GetTowarZamowienium(int id)
        {
          if (_context.TowarZamowienia == null)
          {
              return NotFound();
          }
            var towarZamowienium = await _context.TowarZamowienia.FindAsync(id);

            if (towarZamowienium == null)
            {
                return NotFound();
            }

            return towarZamowienium;
        }

        // PUT: api/TowarZamowienium/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTowarZamowienium(int id, TowarZamowienium towarZamowienium)
        {
            if (id != towarZamowienium.IdTowaruZamowienia)
            {
                return BadRequest();
            }

            _context.Entry(towarZamowienium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TowarZamowieniumExists(id))
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

        // POST: api/TowarZamowienium
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TowarZamowienium>> PostTowarZamowienium(TowarZamowienium towarZamowienium)
        {
          if (_context.TowarZamowienia == null)
          {
              return Problem("Entity set 'SklepInternetowyContext.TowarZamowienia'  is null.");
          }
            _context.TowarZamowienia.Add(towarZamowienium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTowarZamowienium", new { id = towarZamowienium.IdTowaruZamowienia }, towarZamowienium);
        }

        // DELETE: api/TowarZamowienium/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTowarZamowienium(int id)
        {
            if (_context.TowarZamowienia == null)
            {
                return NotFound();
            }
            var towarZamowienium = await _context.TowarZamowienia.FindAsync(id);
            if (towarZamowienium == null)
            {
                return NotFound();
            }

            _context.TowarZamowienia.Remove(towarZamowienium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TowarZamowieniumExists(int id)
        {
            return (_context.TowarZamowienia?.Any(e => e.IdTowaruZamowienia == id)).GetValueOrDefault();
        }
    }
}