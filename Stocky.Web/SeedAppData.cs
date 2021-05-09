using Stocky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky
{
    public static class SeedAppData
    {
        private static string shareKey = Constants.SuperAdminKey;

        public static async Task<bool> Seed(AppDbContext context, ApplicationUser user = null)
        {
            if (context.Customers.Any() == false) await context.Customers.AddRangeAsync(GetCustomers());
            if (context.Products.Any() == false) await context.Products.AddRangeAsync(GetProducts());
            if (context.Suppliers.Any() == false) await context.Suppliers.AddRangeAsync(GetSuppliers());
            if (context.Locations.Any() == false) await context.Locations.AddRangeAsync(GetLocations());
            if (context.Categories.Any() == false) await context.Categories.AddRangeAsync(GetCategories());
            if (context.Brands.Any() == false) await context.Brands.AddRangeAsync(GetBrands());
            if (context.Colors.Any() == false) await context.Colors.AddRangeAsync(GetColors()); 
            if (context.Sizes.Any() == false) await context.Sizes.AddRangeAsync(GetSizes()); 

            return await context.SaveChangesAsync() > 0;
        }

        public static IEnumerable<Customer> GetCustomers()
        {
            // Add Customers
            var customerList = new List<Customer>
            {
                new Customer
                {
                    Name = "Ayan Khan ",
                    City = "Shergarh",
                    Email = "ayan@stocky.com",
                    Address = "",
                    Mobile = "03159900444",
                    IsActive = true,
                    State = "KPK",
                    ZipCode = "23100",
                    SharedKey = shareKey,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new Customer
                {
                    Name = "Ijaz Khan",
                    City = "Shergarh",
                    Email = "ijaz@stocky.com",
                    Address = "",
                    Mobile = "03159900444",
                    IsActive = true,
                    State = "KPK",
                    SharedKey = shareKey,
                    ZipCode = "23100",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new Customer
                {
                    Name = "Ahmad Zeb",
                    City = "Shergarh",
                    Email = "Ahmad@stocky.com",
                    Address = "",
                    SharedKey = shareKey,
                    Mobile = "03159900444",
                    IsActive = true,
                    State = "KPK",
                    ZipCode = "23100"
                },
                new Customer
                {
                    Name = "Waqar Ahmad",
                    City = "Shergarh",
                    Email = "waqar@stocky.com",
                    Address = "",
                    Mobile = "03159900444",
                    SharedKey = shareKey,
                    IsActive = true,
                    State = "KPK",
                    ZipCode = "23100",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new Customer
                {
                     Name = "Adnan Ahmad",
                    City = "Mardan",
                    Email = "adnan@stocky.com",
                    Address = "",
                    SharedKey = shareKey,
                    Mobile = "03159900444",
                    IsActive = true,
                    State = "KPK",
                    ZipCode = "23100",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new Customer
                {
                     Name = "Imran Ahmad",
                    City = "islamabad",
                    Email = "imran@stocky.com",
                    Address = "",
                    SharedKey = shareKey,
                    Mobile = "03159900444",
                    IsActive = true,
                    State = "islamabad",
                    ZipCode = "23100",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new Customer
                {
                     Name = "Asim Ahmad",
                    City = "islamabad",
                    Email = "asim@stocky.com",
                    Address = "",
                    SharedKey = shareKey,
                    Mobile = "03159900444",
                    IsActive = true,
                    State = "islamabad",
                    ZipCode = "23100",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new Customer
                {
                     Name = "Waleed Ahmad",
                    City = "marddan",
                    Email = "waleed@stocky.com",
                    Address = "",
                    Mobile = "03159900444",
                    SharedKey = shareKey,
                    IsActive = true,
                    State = "kpk",
                    ZipCode = "23100",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new Customer
                {
                     Name = "Tasbeeh Ahmad",
                    City = "marddan",
                    Email = "tasbeeh@stocky.com",
                    SharedKey = shareKey,
                    Address = "",
                    Mobile = "03159900444",
                    IsActive = true,
                    State = "kpk",
                    ZipCode = "23100",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new Customer
                {
                     Name = "Aimal Khan",
                    City = "marddan",
                    Email = "aimal@stocky.com",
                    Address = "",
                    SharedKey = shareKey,
                    Mobile = "03159900444",
                    IsActive = true,
                    State = "kpk",
                    ZipCode = "23100",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                 new Customer
                {
                     Name = "Saeed Khan",
                    City = "marddan",
                    Email = "saeed@stocky.com",
                    SharedKey = shareKey,
                    Address = "",
                    Mobile = "03159900444",
                    IsActive = true,
                    State = "kpk",
                    ZipCode = "23100",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            };

            return customerList;
        }

        public static IEnumerable<Supplier> GetSuppliers()
        {
            // Add Suppliers
            var supplierList = new List<Supplier>
            {
               new Supplier
               {
                Id = new Guid("41be776e-e887-484f-8a46-9cf45af5bde3"),
                Name = "Ali",
                SharedKey = shareKey,
                Email = "Ali@yahoo.com",
                City = "Mardan",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100"
               },
               new Supplier
               {
                Name = "Sami",
                SharedKey = shareKey,
                Email = "sami@yahoo.com",
                City = "Mardan",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100",
               },
               new Supplier
               {
                Name = "Zeeshan",
                SharedKey = shareKey,
                Email = "zeshan@yahoo.com",
                City = "peshawar",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100",
               },
               new Supplier
               {
                Name = "Muhammad Raza Khan",
                SharedKey = shareKey,
                Email = "muhammadrazaKhan@yahoo.com",
                City = "sawat",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100",

               },
               new Supplier
               {
                Name = "Jangeer Khan",
                SharedKey = shareKey,
                Email = "jangeer@yahoo.com",
                City = "lahor",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100",
               },
               new Supplier
               {
                Name = "Gul Khan",
                SharedKey = shareKey,
                Email = "gull@yahoo.com",
                City = "karachi",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100",
               },
               new Supplier
               {
                Name = "Umair",
                SharedKey = shareKey,
                Email = "umeer@yahoo.com",
                City = "shergarh",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100",
               },
               new Supplier
               {
                Name = "Numan",
                SharedKey = shareKey,
                Email = "noman@yahoo.com",
                City = "Mardan",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100",
               },
               new Supplier
               {
                Name = "Arsalan Khan",
                SharedKey = shareKey,
                Email = "arsalan@yahoo.com",
                City = "Mardan",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100",
               },
               new Supplier
               {
                Name = "Usman",
                SharedKey = shareKey,
                Email = "usman@yahoo.com",
                City = "islmabad",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100",
               },
               new Supplier
               {
                Name = "Awal Khan",
                SharedKey = shareKey,
                Email = "awal@yahoo.com",
                City = "islmabad",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100",
               },
               new Supplier
               {
                Name = "Nasar Khan",
                SharedKey = shareKey,
                Email = "nasar@yahoo.com",
                City = "islmabad",
                Address1 = "Mardan, College road",
                Phone = "03448373773",
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PostalCode = "23100",
               },
            };

            return supplierList;
        }

        public static IEnumerable<Product> GetProducts()
        {
            var productBrand = new Brand
            {
                IsActive = true,
                Name = "Sample Brand",
                SharedKey = shareKey,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now,
            };

            var blackColor = new Color
            {
                Name = "Black",
                ColorCode = "#000000",
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now,
            };

            // Add Product 
            var productList = new List<Product>
            {
                new Product
                    {
                        BarcodeSystem = BarcodeSystem.EAN,
                        Brand = productBrand,
                        Color = blackColor,
                        Name = "Lays",
                        BuyingPrice = 50,
                        SellingPrice = 60,
                        SharedKey = shareKey,
                        IsActive = true,
                        MinStockLevel = 15,
                        SKU = "123456",
                        Description = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    },
               new Product
                    {
                        BarcodeSystem = BarcodeSystem.EAN,
                        Brand = productBrand,
                        Color = blackColor,
                        Name = "LBaskin Robbinsays",
                        BuyingPrice = 500,
                        SellingPrice = 600,
                        SharedKey = shareKey,
                        IsActive = true,
                        MinStockLevel = 15,
                        SKU = "123457",
                        Description = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    },
               new Product
                    {
                        BarcodeSystem = BarcodeSystem.EAN,
                        Brand = productBrand,
                        Color = blackColor,
                        Name = "Cream of Wheat",
                        BuyingPrice = 150,
                        SellingPrice = 2000,
                        SharedKey = shareKey,
                        IsActive = true,
                        MinStockLevel = 15,
                        SKU = "123458",
                        Description = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,

                    },
               new Product
                    {
                        BarcodeSystem = BarcodeSystem.EAN,
                        Brand = productBrand,
                        Color = blackColor,
                        Name = "Campbells",
                        BuyingPrice = 400,
                        SellingPrice = 500,
                        SharedKey = shareKey,
                        IsActive = true,
                        MinStockLevel = 15,
                        SKU = "123459",
                        Description = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    },
               new Product
                    {
                        BarcodeSystem = BarcodeSystem.EAN,
                        Brand = productBrand,
                        Color = blackColor,
                        Name = "Heinz",
                        BuyingPrice = 70,
                        SellingPrice = 80,
                        SharedKey = shareKey,
                        IsActive = true,
                        MinStockLevel = 15,
                        SKU = "123543",
                        Description = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    },
               new Product
                    {
                        BarcodeSystem = BarcodeSystem.EAN,
                        Brand = productBrand,
                        Color = blackColor,
                        Name = "Cup-a-soup",
                        BuyingPrice = 250,
                        SellingPrice = 260,
                        SharedKey = shareKey,
                        IsActive = true,
                        MinStockLevel = 15,
                        SKU = "1235437",
                        Description = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    },
               new Product
                    {
                        BarcodeSystem = BarcodeSystem.EAN,
                        Brand = productBrand,
                        Color = blackColor,
                        Name = "Hope's Kitchen",
                        BuyingPrice = 80,
                        SellingPrice = 90,
                        SharedKey = shareKey,
                        IsActive = true,
                        MinStockLevel = 15,
                        SKU = "1235438",
                        Description = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    },
               new Product
                    {
                        BarcodeSystem = BarcodeSystem.EAN,
                        Brand = productBrand,
                        Color = blackColor,
                        Name = "Cup Noodles",
                        BuyingPrice = 300,
                        SellingPrice = 350,
                        SharedKey = shareKey,
                        IsActive = true,
                        MinStockLevel = 15,
                        SKU = "188843",
                        Description = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    },
               new Product
                    {
                        BarcodeSystem = BarcodeSystem.EAN,
                        Brand = productBrand,
                        Color = blackColor,
                        Name = "Campbells",
                        BuyingPrice = 320,
                        SellingPrice = 360,
                        SharedKey = shareKey,
                        IsActive = true,
                        MinStockLevel = 15,
                        SKU = "12943",
                        Description = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    },
               new Product
                    {
                        BarcodeSystem = BarcodeSystem.EAN,
                        Brand = productBrand,
                        Color = blackColor,
                        Name = "Pastry",
                        BuyingPrice = 250,
                        SellingPrice = 270,
                        SharedKey = shareKey,
                        IsActive = true,
                        MinStockLevel = 15,
                        SKU = "12354367",
                        Description = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    },
               new Product
                    {
                        BarcodeSystem = BarcodeSystem.EAN,
                        Brand = productBrand,
                        Color = blackColor,
                        Name = "Bread",
                        BuyingPrice = 240,
                        SellingPrice = 310,
                        SharedKey = shareKey,
                        IsActive = true,
                        MinStockLevel = 15,
                        SKU = "1608543",
                        Description = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    },
            };

            return productList;
        }

        public static IEnumerable<Location> GetLocations()
        {
            return new List<Location>
            {
                new Location
                {
                  Id = new Guid("f2a859d4-e0e8-4646-ac61-8d02ac72ece6"), Name = "Default 1", SharedKey = shareKey, CreatedDate = DateTime.Now
                },
                new Location
                {
                  Id = new Guid("14a374ff-eee5-4398-8710-ea2661fbf7ee"),  Name = "Default 2", SharedKey = shareKey, CreatedDate = DateTime.Now
                }
            };
        }

        public static IEnumerable<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {Id = new Guid("4995303b-498d-41dd-aa78-b5d59b6573c7"), IsActive = true, Name = "Basic", SharedKey = shareKey, Description = "Sample Product desc", CreatedDate = DateTime.Now },
                new Category { IsActive = true, Name = "Advance", SharedKey = shareKey, Description = "Sample Product desc 2", CreatedDate = DateTime.Now }
            };
        }

        public static IEnumerable<Brand> GetBrands()
        {
            return new List<Brand>
            {
                new Brand { Id = new Guid("74b1adbc-5f79-44d5-b4e7-7e50b2de181e"), Name = "Proba Brands", SharedKey = shareKey, CreatedDate = DateTime.Now, IsActive = true, Description = "Sample fun"},
                new Brand { Name = "Sample Brand", SharedKey = shareKey, CreatedDate = DateTime.Now, IsActive = true, Description = "Sample fun"}
            };
        }

        public static IEnumerable<Color> GetColors()
        {
            return new List<Color>
            {
                new Color { Id = new Guid("55153073-da70-4ffc-bba3-5b69c7a43a7e"), Name = "Red", ColorCode= "#ff0000", SharedKey = shareKey, CreatedDate = DateTime.Now, IsActive = true},
                new Color { Name = "Black", ColorCode = "#000000", SharedKey = shareKey, CreatedDate = DateTime.Now, IsActive = true}
            };
        }

        public static IEnumerable<Size> GetSizes()
        {
            return new List<Size>
            {
                new Size { Id = new Guid("cc427a06-10fa-4fd2-96d4-5bf3db6f18d9"), Name = "Small", SharedKey = shareKey, CreatedDate = DateTime.Now, IsActive = true},
                new Size { Name = "Medium", SharedKey = shareKey, CreatedDate = DateTime.Now, IsActive = true}
            };
        }

    }
}
