using Demo.Infrastructure;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private ContentContext DbContext { get; }

        [BindProperty]
        public int ProductId { get; set; }
        public Product Product { get; private set; }

        public DetailsModel(ContentContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public void OnGet(int productId)
        {
            this.Product = this.DbContext.Find<Product>(productId);
        }
    }
}
