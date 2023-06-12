using L7_2.Data;
using L7_2.Models;
using Microsoft.EntityFrameworkCore;

namespace L7_2.Repositories
{
    public class ToyRepository : IToyRepository
    {
        private readonly AppDbContext _context;

        public ToyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Toy>> GetAll()
        {
            return await _context.ToyItems.ToListAsync();
        }

        public async Task<Toy> GetById(int id)
        {
            return await _context.ToyItems.FindAsync(id);
        }

        public async Task Create(Toy toy)
        {
            _context.ToyItems.Add(toy);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Toy toy)
        {
            _context.ToyItems.Update(toy);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var toy = await _context.ToyItems.FindAsync(id);
            if (toy != null)
            {
                _context.ToyItems.Remove(toy);
                await _context.SaveChangesAsync();
            }
        }
    }
}
