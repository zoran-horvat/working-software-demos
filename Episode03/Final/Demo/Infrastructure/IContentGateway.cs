using System.Linq;
using Demo.Models;

namespace Demo.Infrastructure
{
    public interface IContentGateway
    {
        public IQueryable<Product> Products { get; }
        public void Add(Product product);
        public void Remove(int productId);
        public int SaveChanges();
    }
}