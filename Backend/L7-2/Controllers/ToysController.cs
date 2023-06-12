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
    public class ToysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Toys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toy>>> GetToyItems()
        {
          if (_context.ToyItems == null)
          {
              return NotFound();
          }
            return await _context.ToyItems.ToListAsync();
        }

        // GET: api/Toys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Toy>> GetToy(int id)
        {
          if (_context.ToyItems == null)
          {
              return NotFound();
          }
            var toy = await _context.ToyItems.FindAsync(id);

            if (toy == null)
            {
                return NotFound();
            }

            return toy;
        }

        // PUT: api/Toys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToy(int id, Toy toy)
        {
            if (id != toy.Id)
            {
                return BadRequest();
            }

            _context.Entry(toy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToyExists(id))
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

        // POST: api/Toys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Toy>> PostToy(Toy toy)
        {
          if (_context.ToyItems == null)
          {
              return Problem("Entity set 'AppDbContext.ToyItems'  is null.");
          }
            _context.ToyItems.Add(toy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToy", new { id = toy.Id }, toy);
        }

        // DELETE: api/Toys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToy(int id)
        {
            if (_context.ToyItems == null)
            {
                return NotFound();
            }
            var toy = await _context.ToyItems.FindAsync(id);
            if (toy == null)
            {
                return NotFound();
            }

            _context.ToyItems.Remove(toy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToyExists(int id)
        {
            return (_context.ToyItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
