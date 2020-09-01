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
                    new User(1, "me", new UserRef("36E7A6B4-ACE8-477F-90EF-671A1A79D901")), 
                    new User(2, "neighbor", new UserRef("07FFAEA2-BBBE-4767-8FCF-D4B4A60F6B22")),
                });

            modelBuilder.ForProduct();
        }
    }
}
