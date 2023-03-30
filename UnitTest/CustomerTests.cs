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
    public class CustomerTests
    {
        //CustomerService _customerService;
        [Fact]
        public void GetTest()
        {
            using (var context = ContextCreater.CreateContext())
            {
                context.Customers.Add(new Customer { Name = "Elias", Address = "Hvor kragerne vender", CustomerId = 1, Email = "test@test.test", Password = "P@ssw0rd" });
                context.SaveChanges();
            }

            using (var context = ContextCreater.CreateContext())
            {
                var _customerService = new CustomerService(context);
                Customer customer = _customerService.GetCustomer(1);

                Assert.Equal("Elias", customer.Name);
            }
        }

        [Fact]
        public void CreateTest()
        {
            using (var context = ContextCreater.CreateContext())
            {
                var _customerService = new CustomerService(context);
                _customerService.AddCustomer(new CustomerDTO { Name = "Elias", Address = "Hvor kragerne vender", Email = "test@test.test", Password = "P@ssw0rd" });
            }

            using (var context = ContextCreater.CreateContext())
            {
                Assert.Equal(1, context.Customers.Count());
            }
        }

        [Fact]
        public void LoginTest()
        {
            using (var context = ContextCreater.CreateContext())
            {
                context.Customers.Add(new Customer { Name = "Elias", Address = "Hvor kragerne vender", CustomerId = 1, Email = "test@test.test", Password = "P@ssw0rd" });
                context.SaveChanges();
            }

            using (var context = ContextCreater.CreateContext())
            {
                var _customerService = new CustomerService(context);
                int? id = _customerService.Login("test@test.test", "P@ssw0rd");

                Assert.Equal(1, id);
            }
        }
    }
}
