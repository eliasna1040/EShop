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
    public class OrderTests
    {
        [Fact]
        public void GetTest()
        {
            using (var context = ContextCreater.CreateContext())
            {
                context.Orders.Add(new Order { Customer = new Customer { Name = "Elias", Address = "Hvor kragerne vender", CustomerId = 1, Email = "test@test.test", Password = "P@ssw0rd" }, Products = new List<Product> { new Product { Name = "G63 AMG", Price = 2500000, Description = "en bil", Category = new Category { Name = "Bil" }, Manufacturer = new Manufacturer { Name = "Mercedes" } }, new Product { Name = "G63 AMG", Price = 2500000, Description = "en bil", CategoryId = 1, ManufacturerId = 1 } } });
                context.SaveChanges();
            }

            using (var context = ContextCreater.CreateContext())
            {
                OrderService orderService = new(context);
                Order? order = orderService.GetOrder(1);

                Assert.Equal("Elias", order?.Customer.Name);
            }
        }

        [Fact]
        public void CreateTest()
        {
            using(var context = ContextCreater.CreateContext())
            {
                context.Products.Add(new Product { Name = "G63 AMG", Description = "det er en bil", Price = 2500000, Category = new Category { Name = "Bil" }, Manufacturer = new Manufacturer { Name = "Mercedes-Benz" } });
                context.Customers.Add(new Customer { Name = "Elias", Address = "Hvor kragerne vender", CustomerId = 1, Email = "test@test.test", Password = "P@ssw0rd" });
                context.SaveChanges();

                OrderService orderService = new(context);
                orderService.CreateOrder(new OrderDTO { CustomerId = 1, ProductIds = new List<int> { 1 } });
            }

            using (var context = ContextCreater.CreateContext())
            {
                OrderService orderService = new(context);
                Order? order = orderService.GetOrder(1);

                Assert.Equal("Elias", order?.Customer.Name);
            }
        }
    }
}
