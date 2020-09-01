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
        private ContentContext DbContext { get; }

        [BindProperty] public string NewProductName { get; set; } = string.Empty;
        public IEnumerable<Product> AllProducts { get; private set; } = Enumerable.Empty<Product>();

        public IndexModel(ContentContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public void OnGet()
        {
            this.AllProducts = this.DbContext.Products.ToList();
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(this.NewProductName))
            {

            }
            return RedirectToPage("/Products/Index");
        }
    }
}
