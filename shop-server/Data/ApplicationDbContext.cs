using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shop_server.Models;

namespace shop_server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }
        
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Order>()
        //        .Property(p => p.ProductsIds)
        //        .HasConversion(
        //            v => string.Join(",", v),
        //            v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
        //        );
        //}

        public DbSet<shop_server.Models.Product> Product { get; set; }
        public DbSet<shop_server.Models.Category> Category { get; set; }
        public DbSet<shop_server.Models.Order> Order { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
    }
    
}
