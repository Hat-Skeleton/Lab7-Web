using L7_2.Data;
using L7_2.Models;
using Microsoft.EntityFrameworkCore;

namespace L7_2.Repositories
{
    public class ClothingRepository : IClothingRepository
    {
        private readonly AppDbContext _context;

        public ClothingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Clothing>> GetAll()
        {
            return await _context.ClothingItems.ToListAsync();
        }

        public async Task<Clothing> GetById(int id)
        {
            return await _context.ClothingItems.FindAsync(id);
        }

        public async Task Create(Clothing clothing)
        {
            _context.ClothingItems.Add(clothing);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Clothing clothing)
        {
            _context.ClothingItems.Update(clothing);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var clothing = await _context.ClothingItems.FindAsync(id);
            if (clothing != null)
            {
                _context.ClothingItems.Remove(clothing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
