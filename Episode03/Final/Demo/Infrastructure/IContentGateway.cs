using System.Linq;
using Demo.Models;

namespace Demo.Infrastructure
{
    public interface IContentGateway
    {
        IQueryable<Product> Products { get; }
        void Add(Product obj);
        void RemoveProduct(int productId);
        int SaveChanges();
    }
}