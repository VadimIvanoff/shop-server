using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using shop_server.Data;
using shop_server.Models;

namespace shop_server.Controllers
{
   
    public class OrdersController : BaseApiController
    {
        public OrdersController(ApplicationDbContext context, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IConfiguration configuration) : base(context, userManager, 
                roleManager, configuration)
        {
        }

        // GET: api/Orders
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getOrders = DbContext.Order.Where(o => o.Customer == User.Identity.Name);
            return Ok(getOrders);
        }

        // POST: api/Orders
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OrderViewModel order)
        {
            if (order.ProductsIds == null)
            {
                return BadRequest("Список товаров пуст");
            } 
            string prodIds = string.Join(",", order.ProductsIds.Select(p => p.ToString()).ToArray());
            string userName = User.Identity.Name;

            Order newOrder = new Order { Customer = userName, DeliveryAddress = order.DeliveryAddress,
                ProdIds = prodIds, Status = "В обработке" };
            DbContext.Order.Add(newOrder);
            try
            {
             await DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
            return Ok(newOrder);
        }

       
    }
}
