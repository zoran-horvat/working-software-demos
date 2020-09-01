using System;
using System.Threading.Tasks;
using Demo.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Demo.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private Lazy<IContentGateway> LazyDbContext { get; }
        private IContentGateway DbContext => this.LazyDbContext.Value;

        public DeleteModel(IContentGatewayFactory dbContextFactory)
        {
            this.LazyDbContext = dbContextFactory.ToLazyContentGateway(this);
        }

        public IActionResult OnPost(int productId)
        {
            this.DbContext.RemoveProduct(productId);
            this.DbContext.SaveChanges();
            return RedirectToPage("/Products/Index");
        }
    }
}
