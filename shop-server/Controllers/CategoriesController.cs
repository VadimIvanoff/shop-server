using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using shop_server.Data;
using shop_server.Models;

namespace shop_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseApiController
    {
  

        public CategoriesController(ApplicationDbContext context,
                                 UserManager<IdentityUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IConfiguration configuration): base(context, userManager, roleManager, configuration)
        {
 
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await DbContext.Category.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await DbContext.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.ID)
            {
                return BadRequest();
            }

            DbContext.Entry(category).State = EntityState.Modified;

            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            DbContext.Category.Add(category);
            await DbContext.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.ID }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await DbContext.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            DbContext.Category.Remove(category);
            await DbContext.SaveChangesAsync();

            return category;
        }

        private bool CategoryExists(int id)
        {
            return DbContext.Category.Any(e => e.ID == id);
        }
    }
}
