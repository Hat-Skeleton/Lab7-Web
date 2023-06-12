using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L7_2.Data;
using L7_2.Models;

namespace L7_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClothingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Clothings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clothing>>> GetClothingItems()
        {
          if (_context.ClothingItems == null)
          {
              return NotFound();
          }
            return await _context.ClothingItems.ToListAsync();
        }

        // GET: api/Clothings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clothing>> GetClothing(int id)
        {
          if (_context.ClothingItems == null)
          {
              return NotFound();
          }
            var clothing = await _context.ClothingItems.FindAsync(id);

            if (clothing == null)
            {
                return NotFound();
            }

            return clothing;
        }

        // PUT: api/Clothings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothing(int id, Clothing clothing)
        {
            if (id != clothing.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingExists(id))
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

        // POST: api/Clothings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clothing>> PostClothing(Clothing clothing)
        {
          if (_context.ClothingItems == null)
          {
              return Problem("Entity set 'AppDbContext.ClothingItems'  is null.");
          }
            _context.ClothingItems.Add(clothing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothing", new { id = clothing.Id }, clothing);
        }

        // DELETE: api/Clothings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothing(int id)
        {
            if (_context.ClothingItems == null)
            {
                return NotFound();
            }
            var clothing = await _context.ClothingItems.FindAsync(id);
            if (clothing == null)
            {
                return NotFound();
            }

            _context.ClothingItems.Remove(clothing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothingExists(int id)
        {
            return (_context.ClothingItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
