using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    public class ContentContext : DbContext
    {
        public DbSet<Product> Products => base.Set<Product>();

        public ContentContext(DbContextOptions<ContentContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForProduct();
        }
    }
}
