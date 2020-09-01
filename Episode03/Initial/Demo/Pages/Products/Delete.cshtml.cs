using System.Linq;
using System.Threading.Tasks;
using Demo.Infrastructure;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Demo.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private ContentContext DbContext { get; }

        public DeleteModel(ContentContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public IActionResult OnPost(int productId)
        {
            Product toDelete = this.DbContext.Products.FirstOrDefault(product => product.Id == productId);
            if (toDelete != null)
            {
                this.DbContext.Remove(toDelete);
                this.DbContext.SaveChanges();
            }
            return RedirectToPage("/Products/Index");
        }
    }
}
