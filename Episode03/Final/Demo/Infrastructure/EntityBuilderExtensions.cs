using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    static class EntityBuilderExtensions
    {
        internal static void ForUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users", "Authentication")
                .Ignore(user => user.Reference)
                .HasKey(user => user.Id);

            modelBuilder.Entity<User>()
                .Property(user => user.UserName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.Key)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(obj => obj.UserName)
                .IsUnique(true);

            modelBuilder.Entity<User>()
                .HasIndex(obj => obj.Key)
                .IsUnique(true);
        }

        internal static void ForProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Products", "Content")
                .Ignore(product => product.OwnerRef)
                .HasKey(product => product.Id);

            modelBuilder.Entity<Product>()
                .Property(product => product.Name)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(product => product.OwnerKey)
                .IsRequired();
        }
    }
}