using L7_2.Data;
using L7_2.Models;
using Microsoft.EntityFrameworkCore;

namespace L7_2.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _context.BookItems.ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _context.BookItems.FindAsync(id);
        }

        public async Task Create(Book book)
        {
            _context.BookItems.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            _context.BookItems.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var book = await _context.BookItems.FindAsync(id);
            if (book != null)
            {
                _context.BookItems.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
