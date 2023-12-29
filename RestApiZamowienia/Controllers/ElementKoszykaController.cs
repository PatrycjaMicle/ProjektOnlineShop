using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;

namespace RestApiZamowienia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementKoszykaController : ControllerBase
    {
        private readonly SklepInternetowyContext _context;

        public ElementKoszykaController(SklepInternetowyContext context)
        {
            _context = context;
        }

        // GET: api/ElementKoszyka
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElementKoszyka>>> GetElementKoszykas()
        {
          if (_context.ElementKoszykas == null)
          {
              return NotFound();
          }
            return await _context.ElementKoszykas.ToListAsync();
        }

        // GET: api/ElementKoszyka/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElementKoszyka>> GetElementKoszyka(int id)
        {
          if (_context.ElementKoszykas == null)
          {
              return NotFound();
          }
            var elementKoszyka = await _context.ElementKoszykas.FindAsync(id);

            if (elementKoszyka == null)
            {
                return NotFound();
            }

            return elementKoszyka;
        }

        // PUT: api/ElementKoszyka/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElementKoszyka(int id, ElementKoszyka elementKoszyka)
        {
            if (id != elementKoszyka.IdElementuKoszyka)
            {
                return BadRequest();
            }

            _context.Entry(elementKoszyka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementKoszykaExists(id))
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

        // POST: api/ElementKoszyka
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ElementKoszyka>> PostElementKoszyka(ElementKoszyka elementKoszyka)
        {
            var existingElementKoszyka= new ElementKoszyka();

            if (_context.ElementKoszykas == null)
            {
                return NotFound();
            }

            if (HttpContext.Items.TryGetValue("user_id", out object userIDObj) && userIDObj is string userID)
            {
                if (!int.TryParse(userID, out _))
                {
                    return BadRequest("Invalid user ID format.");
                }

                Console.WriteLine("Checking if CartItem exists...");

                existingElementKoszyka = await _context.ElementKoszykas
                    .FirstOrDefaultAsync(e => e.IdTowaru == elementKoszyka.IdTowaru && e.IdUzytkownika.ToString() == userID);

                if (existingElementKoszyka != null && existingElementKoszyka.IdTowaru != null)
                {
                    Console.WriteLine("Exists already...");

                    existingElementKoszyka.Ilosc = existingElementKoszyka.Ilosc + 1;

                    _context.Entry(existingElementKoszyka).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    Console.WriteLine("Produkt byl juz w koszyku, zaktualizowano ilosc.");
                }
                else
                {
                    Console.WriteLine("Not exists...");

                    elementKoszyka.IdUzytkownika = int.Parse(userID);
                    elementKoszyka.Ilosc = 1;
                    _context.ElementKoszykas.Add(elementKoszyka);
                    await _context.SaveChangesAsync();

                    Console.WriteLine("Dodano element koszyka!");
                }
            }
            else
            {
                return BadRequest("Unable to retrieve or parse user ID from context.");
            }

            return CreatedAtAction("GetElementKoszyka", new { id = elementKoszyka.IdElementuKoszyka }, elementKoszyka);
        }

        // DELETE: api/ElementKoszyka/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElementKoszyka(int id)
        {
            if (_context.ElementKoszykas == null)
            {
                return NotFound();
            }
            var elementKoszyka = await _context.ElementKoszykas.FindAsync(id);
            if (elementKoszyka == null)
            {
                return NotFound();
            }

            _context.ElementKoszykas.Remove(elementKoszyka);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElementKoszykaExists(int id)
        {
            return (_context.ElementKoszykas?.Any(e => e.IdElementuKoszyka == id)).GetValueOrDefault();
        }
    }
}
