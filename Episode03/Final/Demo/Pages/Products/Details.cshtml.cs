using System;
using System.Linq;
using System.Security.Claims;
using Demo.Infrastructure;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private Lazy<IContentGateway> DbContext { get; }

        [BindProperty]
        public int ProductId { get; set; }
        public Product Product { get; private set; }

        public DetailsModel(IContentGatewayFactory dbContextFactory)
        {
            this.DbContext = dbContextFactory.ToLazyContext(this);
        }

        public void OnGet(int productId)
        {
            this.Product = this.DbContext.Value.Products.First(product => product.Id == productId);
        }
    }
}
