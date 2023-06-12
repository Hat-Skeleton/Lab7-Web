using L7_2.Models;
using Microsoft.EntityFrameworkCore;

namespace L7_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Clothing> ClothingItems { get; set; }
        public DbSet<Book> BookItems { get; set; }
        public DbSet<Toy> ToyItems { get; set; }
    }
}
