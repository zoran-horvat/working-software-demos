using System;
using Demo.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private Lazy<IContentGateway> DbContext { get; }

        public DeleteModel(IContentGatewayFactory dbContextFactory)
        {
            this.DbContext = dbContextFactory.ToLazyContext(this);
        }

        public IActionResult OnPost(int productId)
        {
            this.DbContext.Value.Remove(productId);
            this.DbContext.Value.SaveChanges();
            return RedirectToPage("/Products/Index");
        }
    }
}
