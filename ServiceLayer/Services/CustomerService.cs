using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;
using ServiceLayer.Enums;
using ServiceLayer.ExtensionMethods;
using ServiceLayer.ViewModels;
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

        public CustomerModel? GetCustomer(int id)
        {
            return _context.Customers.Where(x => x.CustomerId == id)
                                     .Include(x => x.Orders).ThenInclude(x => x.OrdersProducts).ThenInclude(x => x.Product)
                                     .AsNoTracking()
                                     .Select(x => new CustomerModel(x))
                                     .FirstOrDefault();
        }

        public Page<CustomerModel> GetCustomers(int page, int count)
        {
            IQueryable<Customer> query = _context.Customers.Include(x => x.Orders).ThenInclude(x => x.OrdersProducts).ThenInclude(x => x.Product).AsNoTracking();

            List<CustomerModel> customers = query.Page(page, count).Select(x => new CustomerModel(x)).ToList();

            return new Page<CustomerModel>() { Items = customers, Total = query.Count(), CurrentPage = page, PageSize = count };
        }

        public UserDTO? Login(string email, string password)
        {
            Customer? customer = _context.Customers.FirstOrDefault(x => x.Email == email && x.Password == password);
            return customer != null ? new UserDTO { Id = customer?.CustomerId, IsAdmin = customer?.Admin ?? false } : null;
        }

        public CustomerModel? AddCustomer(CustomerDTO customer)
        {
            if (_context.Customers.Any(x => x.Email == customer.Email))
            {
                return null;
            }

            Customer addedCustomer = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Address = customer.Address,
                Password = customer.Password,
                Admin = customer.Admin
            }; 
            _context.Customers.Add(addedCustomer);
            _context.SaveChanges();
            _context.Entry(addedCustomer).Reload();
            return new CustomerModel(addedCustomer);
        }

        public CustomerModel? EditCustomer(int id, JsonPatchDocument<Customer> newCustomer)
        {
            Customer? customer = _context.Customers.FirstOrDefault(x => x.CustomerId == id);
            if (customer == null)
            {
                return null;
            }

            newCustomer.ApplyTo(customer);
            _context.Update(customer);
            _context.SaveChanges();

            return new CustomerModel(customer);
        }

        public CustomerModel? DisableCustomer(int customerId)
        {
            Customer? customer = _context.Customers.FirstOrDefault(x => x.CustomerId == customerId);

            if (customer == null)
                return null;

            customer.Disabled = !customer.Disabled;
            _context.SaveChanges();

            return new CustomerModel(customer);
        }
    }
}
