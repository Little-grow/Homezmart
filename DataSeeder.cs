using Homezmart.Models;

namespace Homezmart
{
    // DataSeeder
    public static class DataSeeder
    {
        public static void SeedData(AppDBContext context)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Check if data already exists
            if (!context.Categories.Any())
            {
                // Seed data
                var category = new Category
                {
                    CategoryName = "Electronics"
                };
                context.Categories.Add(category);
                context.SaveChanges();

                var Subcategories = new List<Subcategory>
                {
                    new Subcategory
                    {
                        SubcategoryName = "Smartphones", 
                        CategoryId = category.Id
                    },
                    new Subcategory
                    {
                        SubcategoryName = "Laptops",
                        CategoryId = category.Id
                        
                    },
                    new Subcategory
                    {
                        SubcategoryName = "Tablets", 
                        CategoryId = category.Id    
                    },
                    new Subcategory
                    {
                        SubcategoryName = "Smartwatches", 
                        CategoryId = category.Id
                    },
                    new Subcategory
                    {
                        SubcategoryName = "Headphones", 
                        CategoryId = category.Id
                    }
                };

                context.Subcategories.AddRange(Subcategories);
                context.SaveChanges();

                var Products = new List<Product>
                {
                    new Product
                    {
                      ProductName = "iPhone 15",
                      ProductDescription = "Latest iPhone model",
                      Price = 999.99f,
                      StockQuantity = 100, 
                      CategoryId = category.Id,
                      SubcategoryId = Subcategories[0].Id   
                    }, 

                    new Product
                    {
                      ProductName = "Samsung Galaxy S21",
                      ProductDescription = "Latest Samsung Galaxy model",
                      Price = 899.99f,
                      StockQuantity = 100, 
                      CategoryId = category.Id,
                      SubcategoryId = Subcategories[0].Id
                    },

                    new Product
                    {
                      ProductName = "MacBook Pro",
                      ProductDescription = "Latest MacBook model",
                      Price = 1999.99f,
                      StockQuantity = 100, 
                      CategoryId = category.Id,
                      SubcategoryId = Subcategories[1].Id
                    },


                    new Product
                    {
                      ProductName = "iPad Pro",
                      ProductDescription = "Latest iPad model",
                      Price = 799.99f,
                      StockQuantity = 100, 
                      CategoryId = category.Id,
                      SubcategoryId = Subcategories[0].Id
                    },

                    new Product
                    {
                      ProductName = "Apple Watch Series 6",
                      ProductDescription = "Latest Apple Watch model",
                      Price = 399.99f,
                      StockQuantity = 100,
                      CategoryId = category.Id,
                      SubcategoryId = Subcategories[3].Id
                    },

                    new Product
                    {
                      ProductName = "AirPods Pro",
                      ProductDescription = "Latest AirPods model",
                      Price = 199.99f,
                      StockQuantity = 100, 
                      CategoryId = category.Id,
                      SubcategoryId = Subcategories[4].Id
                    }
                };
    
                 context.Products.AddRange(Products);
                // Save changes to the database
                context.SaveChanges();
            }
        }
    }

}
