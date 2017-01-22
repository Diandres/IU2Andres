using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IU2Andres.Data;
using IU2Andres.Models.WebShopModels;

namespace IU2Andres.Models
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();


            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
            new Category{CategoryName="Pizza"},
            new Category{CategoryName="Salad" },
            new Category{CategoryName="Pasta" },
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
            {new Product
                {
                    ProductName = "Margarita",
                    Description = "3 kinds of ost.",
                    ImagePath="carconvert.png",
                    UnitPrice = 22.50,
                    CategoryID = 1
               },
                new Product
                {
                    ProductName = "Cesar Salar",
                    Description = "Chicken and cesar salad ",
                    ImagePath="carearly.png",
                    UnitPrice = 15.95,
                    CategoryID = 2
               },
                new Product
                {
                    ProductName = "Pasta Carbonara",
                    Description = "Pene al dente and bacon",
                    ImagePath="carfast.png",
                    UnitPrice = 32.99,
                    CategoryID = 3
                },
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            
        }
    }
}
