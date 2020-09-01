using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Demo.Infrastructure;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class IndexModel : PageModel
    {
        private Lazy<IContentGateway> LazyDbContext { get; }
        private IContentGateway DbContext => this.LazyDbContext.Value;

        [BindProperty] public string NewProductName { get; set; } = string.Empty;
        public IEnumerable<Product> AllProducts { get; private set; } = Enumerable.Empty<Product>();

        public IndexModel(IContentGatewayFactory dbContextFactory)
        {
            this.LazyDbContext = dbContextFactory.ToLazyContentGateway(this);
        }

        public void OnGet()
        {
            this.AllProducts = this.DbContext.Products.ToList();
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(this.NewProductName))
            {
                string ownerKey = base.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                Product newProduct = new Product(0, this.NewProductName, new UserRef(ownerKey));
                this.DbContext.Add(newProduct);
                this.DbContext.SaveChanges();
            }
            return RedirectToPage("/Products/Index");
        }
    }
}
