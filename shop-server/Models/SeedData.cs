using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shop_server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_server.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.Category.Any())
                {
                    #region Add Category
                    context.Category.AddRange(
                        new Category
                        {
                            Name = "Телефоны",
                            Description = "Сотовые телефоны",
                            Icon = "phone"
                        },
                        new Category
                        {
                            Name = "Компьютеры",
                            Description = "Персональные компьютеры, ноутбуки",
                            Icon = "computer"
                        },
                        new Category
                        {
                            Name = "Принтеры",
                            Description = "Принетры, сканеры, факсы",
                            Icon = "print"
                        },
                        new Category
                        {
                            Name = "Телевизоры",
                            Description = "Телевизоры, проекторы и т.д.",
                            Icon = "tv"
                        },
                        new Category
                        {
                            Name = "Фото и видео",
                            Description = "Фотоаппараты, камеры",
                            Icon = "photo_camera"
                        },
                        new Category
                        {
                            Name = "Гаджеты",
                            Description = "Умные штуки",
                            Icon = "android"
                        },
                        new Category
                        {
                            Name = "Игры, Софт",
                            Description = "Игры, софт",
                            Icon = "phone"
                        }
                        );
                    #endregion
                    context.SaveChanges();
                }
                if (!context.Product.Any())
                {
                    #region Add Products
                    var getFirstCategory = context.Category.FirstOrDefault();
                    context.Product.AddRange(
                        new Product
                        {
                            Name = "Samsung A10",
                            Description = "Новейшая модель любимого телефона",
                            Price = 50000M,
                            Rating = 4,
                            CategoryId = getFirstCategory.ID
                        },
                          new Product
                          {
                              Name = "Samsung A10",
                              Description = "Новейшая модель любимого телефона",
                              Price = 50000M,
                              Rating = 4,
                              CategoryId = getFirstCategory.ID
                          },
                            new Product
                            {
                                Name = "Samsung A10",
                                Description = "Новейшая модель любимого телефона",
                                Price = 50000M,
                                Rating = 4,
                                CategoryId = getFirstCategory.ID
                            },
                              new Product
                              {
                                  Name = "Samsung A10",
                                  Description = "Новейшая модель любимого телефона",
                                  Price = 50000M,
                                  Rating = 4,
                                  CategoryId = getFirstCategory.ID
                              }
                        );
                    #endregion
                    context.SaveChanges();
                }

              
                
               
            }
        }
    }
}
