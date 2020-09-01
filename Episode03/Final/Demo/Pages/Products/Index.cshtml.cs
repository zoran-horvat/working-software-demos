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
        private Lazy<IContentGateway> DbContext { get; }

        [BindProperty] public string NewProductName { get; set; } = string.Empty;
        public IEnumerable<Product> AllProducts { get; private set; } = Enumerable.Empty<Product>();

        public IndexModel(IContentGatewayFactory dbContextFactory)
        {
            this.DbContext = dbContextFactory.ToLazyContext(this);
        }

        public void OnGet()
        {
            this.AllProducts = this.DbContext.Value.Products.ToList();
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(this.NewProductName))
            {
                UserRef owner = this.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
                Product newProduct = new Product(0, this.NewProductName, owner);
                this.DbContext.Value.Add(newProduct);
                this.DbContext.Value.SaveChanges();
            }
            return RedirectToPage("/Products/Index");
        }
    }
}
