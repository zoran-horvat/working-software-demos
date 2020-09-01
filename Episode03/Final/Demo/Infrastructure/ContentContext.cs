using System.Linq;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    public class ContentContext : DbContext, IContentGateway
    {
        public IQueryable<Product> Products => base.Set<Product>().Where(product => product.OwnerKey == this.Owner.Key);
        private UserRef Owner { get; }

        public ContentContext(DbContextOptions<ContentContext> options, UserRef owner) : base(options)
        {
            this.Owner = owner;
        }
        
        public void Add(Product product)
        {
            if (product.OwnerKey == this.Owner.Key)
            {
                base.Set<Product>().Add(product);
            }
        }

        public void Remove(int productId)
        {
            if (this.Products.FirstOrDefault(product => product.Id == productId) is Product toRemove)
            {
                base.Set<Product>().Remove(toRemove);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForProduct();
        }
    }
}
