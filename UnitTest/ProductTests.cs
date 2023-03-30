using DataLayer.Entities;
using ServiceLayer.DTOs;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class ProductTests
    {
        [Fact]
        public void GetTest()
        {
            using (var context = ContextCreater.CreateContext())
            {
                context.Products.Add(new Product { Name = "G63 AMG", Description = "det er en bil", Price = 2500000, Category = new Category { Name = "Bil" }, Manufacturer = new Manufacturer { Name = "Mercedes-Benz" } });
                context.SaveChanges();
            }

            using (var context = ContextCreater.CreateContext())
            {
                ProductService productService = new(context);
                Product? product = productService.GetProduct(1);
                Assert.Equal("G63 AMG", product.Name);
            }
        }

        [Fact]
        public void PagingTest()
        {
            using (var context = ContextCreater.CreateContext())
            {
                for (int i = 1; i < 25; i++)
                {
                    context.Products.Add(new Product { Name = $"G63 AMG {i}", Description = "det er en bil", Price = 2500000, Category = new Category { Name = "Bil" }, Manufacturer = new Manufacturer { Name = "Mercedes-Benz" } });
                }
                context.SaveChanges();
            }

            using (var context = ContextCreater.CreateContext())
            {
                ProductService productService = new(context);
                List<Product> products = productService.GetProducts(1, 5);
                Assert.Equal(5, products.Count);
                Assert.Equal("G63 AMG 5", products.Last().Name);
            }
        }

        [Fact]
        public void CreateTest()
        {
            using (var context = ContextCreater.CreateContext())
            {
                context.Categories.Add(new Category { Name = "Bil" });
                context.Manufacturers.Add(new Manufacturer { Name = "Mercedes-Benz" });
                context.SaveChanges();

                ProductService productService = new(context);
                productService.AddProduct(new ProductDTO { Name = "G63 AMG", Description = "det er en bil", Price = 2500000, CategoryId = 1, ManufacturerId = 1 });
                context.SaveChanges();
            }

            using (var context = ContextCreater.CreateContext())
            {
                ProductService productService = new(context);
                Product? product = productService.GetProduct(1);
                Assert.Equal("G63 AMG", product.Name);
            }
        }

        [Fact]
        public void UpdateTest()
        {
            using (var context = ContextCreater.CreateContext())
            {
                Product product = new Product { Name = "G63 AMG", Description = "det er en bil", Price = 2500000, Category = new Category { Name = "Bil" }, Manufacturer = new Manufacturer { Name = "Mercedes-Benz" } };
                context.Products.Add(product);
                context.SaveChanges();

                ProductService productService = new(context);
                product.Name = "EQS";
                productService.EditProduct(product);
            }

            using (var context = ContextCreater.CreateContext())
            {
                ProductService productService = new(context);
                Product? product = productService.GetProduct(1);
                Assert.Equal("EQS", product.Name);
            }
        }

        [Fact]
        public void DisableTest()
        {
            using (var context = ContextCreater.CreateContext())
            {
                Product product = new Product { Name = "G63 AMG", Description = "det er en bil", Price = 2500000, Category = new Category { Name = "Bil" }, Manufacturer = new Manufacturer { Name = "Mercedes-Benz" } };
                context.Products.Add(product);
                context.SaveChanges();

                ProductService productService = new(context);
                productService.DisableProduct(1);
            }

            using (var context = ContextCreater.CreateContext())
            {
                ProductService productService = new(context);
                Product? product = productService.GetProduct(1);
                Assert.True(product.Disabled);
            }
        }
    }
}
