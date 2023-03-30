using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly EShopContext _context;

        public CustomerService(EShopContext context)
        {
            _context = context;
        }

        public Customer? GetCustomer(int id)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(x => x.CustomerId == id);
        }

        public int? Login(string email, string password)
        {
            return _context.Customers.FirstOrDefault(x => x.Email == email && x.Password == password)?.CustomerId;
        }

        public void AddCustomer(CustomerDTO customer)
        {
            _context.Customers.Add(new Customer { Name = customer.Name, Email = customer.Email, Address = customer.Address, Password = customer.Password });
            _context.SaveChanges();
        }
    }
}
