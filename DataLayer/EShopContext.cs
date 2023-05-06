using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }

        public EShopContext(DbContextOptions<EShopContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });

            modelBuilder.Entity<Category>().HasData(new Category { Name = "bil", CategoryId = 1 });
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer { Name = "Mercedes-Benz", ManufacturerId = 1 });
            //modelBuilder.Entity<Image>().HasData(new Image { ImageData = File.ReadAllBytes(@"C:\Users\c98101ena\OneDrive - Ejner Hessel A S\Pictures\Skærmbillede 2023-04-05 203606.png"), ImageId = 1 });
            modelBuilder.Entity<Product>().HasData(new List<Product>
            { 
                new Product { ProductId = 2, Name = "g63 amg", CategoryId = 1, Description = "en bil", ManufacturerId = 1, Price = 2000000 }, 
                new Product { ProductId = 3, Name = "g63 amg", CategoryId = 1, Description = "en bil", ManufacturerId = 1, Price = 2000000 }, 
                new Product { ProductId = 4, Name = "g63 amg", CategoryId = 1, Description = "en bil", ManufacturerId = 1, Price = 2000000 }, 
                new Product { ProductId = 5, Name = "g63 amg", CategoryId = 1, Description = "en bil", ManufacturerId = 1, Price = 2000000 }, 
                new Product { ProductId = 6, Name = "g63 amg", CategoryId = 1, Description = "en bil", ManufacturerId = 1, Price = 2000000 }, 
                new Product { ProductId = 7, Name = "g63 amg", CategoryId = 1, Description = "en bil", ManufacturerId = 1, Price = 2000000 }, 
                new Product { ProductId = 8, Name = "g63 amg", CategoryId = 1, Description = "en bil", ManufacturerId = 1, Price = 2000000 }, 
                new Product { ProductId = 9, Name = "g63 amg", CategoryId = 1, Description = "en bil", ManufacturerId = 1, Price = 2000000 }, 
                new Product { ProductId = 10, Name = "g63 amg", CategoryId = 1, Description = "en bil", ManufacturerId = 1, Price = 2000000 }, 
                new Product { ProductId = 11, Name = "g63 amg", CategoryId = 1, Description = "en bil", ManufacturerId = 1, Price = 2000000 }, 
            });
            modelBuilder.Entity<Customer>().HasData(new Customer { Name = "Elias", Address = "Hvor kragerne vender", CustomerId = 1, Email = "test@test.test", Password = "P@ssw0rd", Admin = false });
        }
    }
}
