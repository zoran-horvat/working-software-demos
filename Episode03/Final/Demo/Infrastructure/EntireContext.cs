using System;
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
                    new User(1, "me", "B1417667-2221-4CC0-BF9B-58644DD3FB53"), 
                    new User(2, "neighbor", "41AB23B3-3F24-4786-AAAB-ED296605A66F"),
                });

            modelBuilder.ForProduct();
        }
    }
}
