using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shop_server.Data;
using shop_server.Models;

namespace shop_server.Pages.Products
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class DetailsModel : PageModel
    {
        private readonly shop_server.Data.ApplicationDbContext _context;

        public DetailsModel(shop_server.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
