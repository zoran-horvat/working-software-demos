using System.Linq;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    public class SecureContentContext : DbContext, IContentGateway
    {
        private UserRef Owner { get; }
        public IQueryable<Product> Products => base.Set<Product>().Where(product => product.OwnerKey == this.Owner.Value);

        public SecureContentContext(DbContextOptions<SecureContentContext> options, UserRef owner) : base(options)
        {
            this.Owner = owner;
        }
        
        public void Add(Product obj)
        {
            if (obj.OwnerKey == this.Owner.Value)
            {
                base.Set<Product>().Add(obj);
            }
        }

        public void RemoveProduct(int productId)
        {
            Product toDelete = this.Set<Product>().FirstOrDefault(product => 
                product.OwnerKey == this.Owner.Value && product.Id == productId);
            if (toDelete != null)
            {
                this.Set<Product>().Remove(toDelete);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForProduct();
        }
    }
}
