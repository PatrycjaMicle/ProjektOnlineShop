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

            if (HttpContext.Items.TryGetValue("user_id", out object userIDObj) && userIDObj is string)
            {
                string userID = (string)userIDObj;
            }
            else
            {
                Console.WriteLine("unable to get userID from context");
            }


            if (_context.ElementKoszykas == null)
            {
                return Problem("Entity set 'SklepInternetowyContext.ElementKoszykas' is null.");
            }

            if (userIDObj is string userIDString)
            {
                if (int.TryParse(userIDString, out int userID))
                {
                    elementKoszyka.IdUzytkownika = userID;
                }
                else
                {
                    return BadRequest("Invalid user ID format.");
                }
            }
            else
            {
                return BadRequest("User ID is not a valid string.");
            }

            _context.ElementKoszykas.Add(elementKoszyka);

            Console.WriteLine("********Dodano element koszyka: *************", elementKoszyka);

            await _context.SaveChangesAsync();

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


        [HttpGet("CheckIfExists")]
        public async Task<ActionResult<ElementKoszyka>> CheckIfElementKoszykaExists(ElementKoszyka elementKoszyka)
        {
            Console.WriteLine("Checking if CartItem exists...*******");

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

                var existingElementKoszyka = await _context.ElementKoszykas
                    .FirstOrDefaultAsync(e => e.IdTowaru == elementKoszyka.IdTowaru && e.IdUzytkownika.ToString() == userID);

                if (existingElementKoszyka != null)
                {
                    Console.WriteLine("Exists already...*******");
                    return existingElementKoszyka;
                }
                else
                {
                    Console.WriteLine("Not exists...*******");
                    return NotFound();
                }
            }
            else
            {
                return BadRequest("Unable to retrieve or parse user ID from context.");
            }
        }

        private bool ElementKoszykaExists(int id)
        {
            return (_context.ElementKoszykas?.Any(e => e.IdElementuKoszyka == id)).GetValueOrDefault();
        }
    }
}
