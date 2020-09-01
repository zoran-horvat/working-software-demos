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
        private Lazy<IContentGateway> LazyDbContext { get; }
        private IContentGateway DbContext => this.LazyDbContext.Value;

        public Product Product { get; private set; }

        public DetailsModel(IContentGatewayFactory dbContextFactory)
        {
            this.LazyDbContext = dbContextFactory.ToLazyContentGateway(this);
        }

        public void OnGet(int productId)
        {
            this.Product = this.DbContext.Products.First(product => product.Id == productId);
        }
    }
}
