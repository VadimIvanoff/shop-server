﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shop_server.Data;
using shop_server.Models;

namespace shop_server.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly shop_server.Data.ApplicationDbContext _context;

        public IndexModel(shop_server.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order.ToListAsync();
        }
    }
}
