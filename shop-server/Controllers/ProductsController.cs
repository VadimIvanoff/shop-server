using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using shop_server.Data;
using shop_server.Models;
using System.IO;

namespace shop_server.Controllers
{

    public class ProductsController : BaseApiController
    {
        IHostingEnvironment hostingEnvironment;
        public ProductsController(ApplicationDbContext context,
                                 UserManager<IdentityUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IConfiguration configuration,
                                 IHostingEnvironment hostEnv) : base(context, userManager,
                                                                      roleManager, configuration)
        {
            hostingEnvironment = hostEnv;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {

            return await DbContext.Product.ToListAsync();
        }
        [HttpGet("category/{cat}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory([FromRoute]string cat)
        {

            return await DbContext.Product.Include(p => p.Category).Where(p => p.Category.Name == cat).ToListAsync();
        }
        [HttpGet("imagesmall/{id}")]
        public async Task<IActionResult> GetSmallImage(int id)
        {
            var productImage = await DbContext.ProductImage.FirstOrDefaultAsync(i => i.ProductId == id);
            if (productImage != null)
            {
                string name = id + "_small.jpeg";
                string path = hostingEnvironment.WebRootPath + "/catalog/images/" + name;
                byte[] img = System.IO.File.ReadAllBytes(path);
                return File(img, productImage.ContentType, name);
            }
            return BadRequest("Image not Found");
        }
        [HttpGet("imagebig/{id}")]
        public async Task<IActionResult> GetBigImage(int id)
        {
            var productImage = await DbContext.ProductImage.FirstOrDefaultAsync(i => i.ProductId == id);
            if (productImage != null)
            {
                string name = id + "_big.jpeg";
                string path = hostingEnvironment.WebRootPath + "/catalog/images/" + name;
                byte[] img = System.IO.File.ReadAllBytes(path);
                return File(img, productImage.ContentType, name);
            }
            return BadRequest("Image not Found");
        }
        [HttpPost("search")]
        public IActionResult Search([FromBody]SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
            {
                return NotFound();
            }
            IEnumerable<Product> products = null;
            switch (searchCriteria.Type)
            {
                case "rating":
                     products = DbContext.Product.Where(p => p.Rating >= Int32.Parse(searchCriteria.Rating));
                    break;             
                case "price":
                    if (searchCriteria.From != 0 && searchCriteria.To != 0) 
                    {
                        products = DbContext.Product.Where(p => p.Price >= searchCriteria.From && p.Price <= searchCriteria.To);
                    } else if (searchCriteria.From != 0)
                    {
                        products = DbContext.Product.Where(p => p.Price >= searchCriteria.From);
                    } else
                    {
                        products = DbContext.Product.Where(p => p.Price <= searchCriteria.To);
                    }
                    break;
                case "search":
                     products = DbContext.Product.Where(p => p.Description.Contains(searchCriteria.Search) ||  p.Name.Contains(searchCriteria.Search));
                    break;
            }
            return Ok(products.ToArray());
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await DbContext.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }

            DbContext.Entry(product).State = EntityState.Modified;

            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            DbContext.Product.Add(product);
            await DbContext.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ID }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await DbContext.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            DbContext.Product.Remove(product);
            await DbContext.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return DbContext.Product.Any(e => e.ID == id);
        }
    }
}
