using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhotoSauce.MagicScaler;
using shop_server.Data;
using shop_server.Helpers;
using shop_server.Models;

namespace shop_server.Pages.Products
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class CreateModel : PageModel
    {
        private readonly shop_server.Data.ApplicationDbContext _context;
        private IHostingEnvironment appEnvironment;


        public CreateModel(shop_server.Data.ApplicationDbContext context, IHostingEnvironment appEnv)
        {
            _context = context;
            appEnvironment = appEnv;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Category, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public IFormFile uploadedFile { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            ProductImage newImage;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // add product to get id
            if (uploadedFile != null)
            {
                Product.HasImage = true;
            }
                _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            // Save images of product
            #region Image Processing
            if (uploadedFile != null)
            {
               
                _context.ProductImage.Add(await ImageHandler.ProcessImage(uploadedFile, Product.ID, appEnvironment.WebRootPath));
                await _context.SaveChangesAsync();
            }
            #endregion
           

            return RedirectToPage("./Index");
        }
    }
}