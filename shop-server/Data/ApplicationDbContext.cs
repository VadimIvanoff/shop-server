using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shop_server.Models;

namespace shop_server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<shop_server.Models.Product> Product { get; set; }
        public DbSet<shop_server.Models.Category> Category { get; set; }
        public DbSet<shop_server.Models.Order> Order { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
    }
}
