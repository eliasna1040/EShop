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
            modelBuilder.Entity<Category>().HasData(new Category { Name = "bil", CategoryId = 1 });
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer { Name = "Mercedes-Benz", ManufacturerId = 1 });
            modelBuilder.Entity<Image>().HasData(new Image { ImageData = File.ReadAllBytes(@"C:\Users\c98101ena\OneDrive - Ejner Hessel A S\Pictures\Skærmbillede 2023-04-05 203606.png"), ImageId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 1, Name = "g63 amg", CategoryId = 1, Description = "en bil", ManufacturerId = 1, Price = 2000000, ImageId = 1 });
            modelBuilder.Entity<Customer>().HasData(new Customer { Name = "Elias", Address = "Hvor kragerne vender", CustomerId = 1, Email = "test@test.test", Password = "P@ssw0rd" });
        }
    }
}
