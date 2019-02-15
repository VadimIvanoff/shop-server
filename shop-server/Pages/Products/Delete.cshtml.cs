using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shop_server.Data;
using shop_server.Helpers;
using shop_server.Models;

namespace shop_server.Pages.Products
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class DeleteModel : PageModel
    {
        private readonly shop_server.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment appEnv;

        public DeleteModel(shop_server.Data.ApplicationDbContext context, IHostingEnvironment _appEnv)
        {
            _context = context;
            appEnv = _appEnv;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                .Include(p => p.Category).FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FindAsync(id);


            if (Product != null)
            {
                ProductImage image = await _context.ProductImage.FirstOrDefaultAsync(i => i.ID == Product.ID);
                if (image != null)
                {
                    ImageHandler.DeleteImage(Product.ID, appEnv.WebRootPath);
                    _context.ProductImage.Remove(image);
                }
                _context.Product.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
