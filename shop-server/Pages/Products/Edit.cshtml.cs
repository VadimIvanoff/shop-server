using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shop_server.Data;
using shop_server.Helpers;
using shop_server.Models;

namespace shop_server.Pages.Products
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class EditModel : PageModel
    {
        private readonly shop_server.Data.ApplicationDbContext _context;
        private IHostingEnvironment appEnvironment;
        public ProductImage image;
        public EditModel(shop_server.Data.ApplicationDbContext context, IHostingEnvironment appEnv)
        {
            _context = context;
            appEnvironment = appEnv;
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public IFormFile uploadedFile { get; set; }
        [BindProperty]
        public bool DeleteImages { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                .Include(p => p.Category).FirstOrDefaultAsync(m => m.ID == id);
            image = _context.ProductImage.FirstOrDefault(i => i.ProductId == Product.ID);
            if (image != null)
            {
                ViewData["imageSmall"] = image.Path + Product.ID + "_" + "small.jpeg";
                ViewData["imageBig"] =  image.Path + Product.ID + "_" + "big.jpeg";

            }
            
            if (Product == null)
            {
                return NotFound();
            }
           ViewData["CategoryId"] = new SelectList(_context.Category, "ID", "Name");
         
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (uploadedFile != null)
            {
                Product.HasImage = true;
            }
          
            if (Product.HasImage && DeleteImages)
            {
                var image = await _context.ProductImage.FirstOrDefaultAsync(i => i.ProductId == Product.ID);
                if (image != null)
                {
                    Product.HasImage = false;
                    _context.ProductImage.Remove(image);
                    ImageHandler.DeleteImage(Product.ID, appEnvironment.WebRootPath);
                }
            }
            _context.Product.Update(Product);
            try
            {       
                if (uploadedFile != null)
                {
                    _context.ProductImage.Add(await ImageHandler.ProcessImage(uploadedFile, Product.ID, appEnvironment.WebRootPath));      
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ID == id);
        }
    }
}
