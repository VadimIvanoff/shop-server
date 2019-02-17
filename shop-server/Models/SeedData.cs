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
                            Description = "Новейшая модель любимого телефона, мощная камера, быстрый фокус",
                            Price = 50000M,
                            Rating = 4,
                            CategoryId = 1,
                            HasImage = true
                        },
                          new Product
                          {
                              Name = "Apple X",
                              Description = "Непревзойденный лидер на рынке смартфонов, уникальный дизайн, уникальная цена",
                              Price = 70000M,
                              Rating = 5,
                              CategoryId = 1,
                              HasImage = true
                          },
                            new Product
                            {
                                Name = "Honor 9",
                                Description = "Мощный, стильный, недорогой. Отличное соотношение цена качество",
                                Price = 20000M,
                                Rating = 4,
                                CategoryId = 1,
                                HasImage = true
                            },
                              new Product
                              {
                                  Name = "Samsung 60TV",
                                  Description = "Огромный экран, отличное качество изображения от известного производителя",
                                  Price = 37000M,
                                  Rating = 5,
                                  CategoryId = 4,
                                  HasImage = true
                              },
                              new Product
                              {
                                  Name = "Philips 50TV",
                                  Description = "Огромный экран, отличное качество изображения от известного производителя",
                                  Price = 40000M,
                                  Rating = 5,
                                  CategoryId = 4,
                                  HasImage = true
                              },
                              new Product
                              {
                                  Name = "Sony 42TV",
                                  Description = "Огромный экран, отличное качество изображения от известного производителя",
                                  Price = 45000M,
                                  Rating = 5,
                                  CategoryId = 4,
                                  HasImage = true
                              },
                              new Product
                              {
                                  Name = "Canon 600",
                                  Description = "Новая модель, отличное качество фотоснимков с матрицей нового поколения",
                                  Price = 30000M,
                                  Rating = 5,
                                  CategoryId = 5,
                                  HasImage = true
                              },
                              new Product
                              {
                                  Name = "Sony Alpha",
                                  Description = "Новая модель, отличное качество фотоснимков с матрицей нового поколения",
                                  Price = 65000M,
                                  Rating = 5,
                                  CategoryId = 5,
                                  HasImage = true
                              },
                              new Product
                              {
                                  Name = "Nicon D5300",
                                  Description = "Новая модель, отличное качество фотоснимков с матрицей нового поколения",
                                  Price = 30000M,
                                  Rating = 2,
                                  CategoryId = 5,
                                  HasImage = true
                              },
                               new Product
                               {
                                   Name = "Epson 300",
                                   Description = "Новая модель, отличное качество печати с технологией нового поколения",
                                   Price = 30000M,
                                   Rating = 2,
                                   CategoryId = 3,
                                   HasImage = true
                               },
                                new Product
                                {
                                    Name = "Canon 6000",
                                    Description = "Новая модель, отличное качество печати с технологией нового поколения",
                                    Price = 31000M,
                                    Rating = 2,
                                    CategoryId = 3,
                                    HasImage = true
                                },
                                 new Product
                                 {
                                     Name = "Xerox 3434",
                                     Description = "Новая модель, отличное качество печати с технологией нового поколения",
                                     Price = 29000M,
                                     Rating = 2,
                                     CategoryId = 3,
                                     HasImage = true
                                 },
                                  new Product
                                  {
                                      Name = "Imango 2000",
                                      Description = "Новая модель, высокая прозводительность при низкой цене",
                                      Price = 28000M,
                                      Rating = 3,
                                      CategoryId = 2,
                                      HasImage = true
                                  },
                                   new Product
                                   {
                                       Name = "CityLine 6000",
                                       Description = "Новая модель, высокая прозводительность при низкой цене",
                                       Price = 33000M,
                                       Rating = 4,
                                       CategoryId = 2,
                                       HasImage = true
                                   },
                                    new Product
                                    {
                                        Name = "PowerCube 300",
                                        Description = "Новая модель, высокая прозводительность при низкой цене",
                                        Price = 39000M,
                                        Rating = 1,
                                        CategoryId = 2,
                                        HasImage = true
                                    }



                        );
                    #endregion
                    context.SaveChanges();
                }
                #region Add Images
                if (!context.ProductImage.Any())
                {
                    context.ProductImage.AddRange(
                        new ProductImage
                        {
                            Name = "1.jpeg",
                            Path = "/catalog/images/",
                            Type = null,
                            ContentType = "image/jpeg",
                            ProductId = 1
                        },
                         new ProductImage
                         {
                             Name = "2.jpeg",
                             Path = "/catalog/images/",
                             Type = null,
                             ContentType = "image/png",
                             ProductId = 2
                         },
                          new ProductImage
                          {
                              Name = "3.jpeg",
                              Path = "/catalog/images/",
                              Type = null,
                              ContentType = "image/jpeg",
                              ProductId = 3
                          },
                          new ProductImage
                          {
                              Name = "4.jpeg",
                              Path = "/catalog/images/",
                              Type = null,
                              ContentType = "image/jpeg",
                              ProductId = 4
                          },
                          new ProductImage
                          {
                              Name = "5.jpeg",
                              Path = "/catalog/images/",
                              Type = null,
                              ContentType = "image/jpeg",
                              ProductId = 5
                          },
                          new ProductImage
                          {
                              Name = "6.jpeg",
                              Path = "/catalog/images/",
                              Type = null,
                              ContentType = "image/jpeg",
                              ProductId = 6
                          },
                           new ProductImage
                           {
                               Name = "7.jpeg",
                               Path = "/catalog/images/",
                               Type = null,
                               ContentType = "image/jpeg",
                               ProductId = 7
                           },
                            new ProductImage
                            {
                                Name = "8.jpeg",
                                Path = "/catalog/images/",
                                Type = null,
                                ContentType = "image/jpeg",
                                ProductId = 8
                            },
                             new ProductImage
                             {
                                 Name = "9.jpeg",
                                 Path = "/catalog/images/",
                                 Type = null,
                                 ContentType = "image/jpeg",
                                 ProductId = 9
                             },
                             new ProductImage
                             {
                                 Name = "10.jpeg",
                                 Path = "/catalog/images/",
                                 Type = null,
                                 ContentType = "image/jpeg",
                                 ProductId = 10
                             },
                             new ProductImage
                             {
                                 Name = "11.jpeg",
                                 Path = "/catalog/images/",
                                 Type = null,
                                 ContentType = "image/jpeg",
                                 ProductId = 11
                             },
                             new ProductImage
                             {
                                 Name = "12.jpeg",
                                 Path = "/catalog/images/",
                                 Type = null,
                                 ContentType = "image/jpeg",
                                 ProductId = 12
                             },
                             new ProductImage
                             {
                                 Name = "13.jpeg",
                                 Path = "/catalog/images/",
                                 Type = null,
                                 ContentType = "image/jpeg",
                                 ProductId = 13
                             },
                             new ProductImage
                             {
                                 Name = "14.jpeg",
                                 Path = "/catalog/images/",
                                 Type = null,
                                 ContentType = "image/jpeg",
                                 ProductId = 14
                             },
                             new ProductImage
                             {
                                 Name = "15.jpeg",
                                 Path = "/catalog/images/",
                                 Type = null,
                                 ContentType = "image/jpeg",
                                 ProductId = 15
                             }



                        );
                }
                #endregion
                context.SaveChanges();



            }
        }
    }
}
