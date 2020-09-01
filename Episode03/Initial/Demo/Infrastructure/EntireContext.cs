using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    public class EntireContext : DbContext
    {
        public EntireContext(DbContextOptions<EntireContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForUser();

            modelBuilder.Entity<User>()
                .HasData(new[]
                {
                    new User(1, "me"), 
                    new User(2, "neighbor"),
                });

            modelBuilder.ForProduct();
        }
    }
}
