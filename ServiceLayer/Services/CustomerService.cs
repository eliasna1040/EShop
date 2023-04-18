using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;
using ServiceLayer.Enums;
using ServiceLayer.ExtensionMethods;
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

        public Page<Customer> GetCustomers(int page, int count)
        {
            IQueryable<Customer> query = _context.Customers.AsNoTracking();

            //if (!string.IsNullOrWhiteSpace(search))
            //{
            //    query = query.Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Manufacturer.Name.ToLower().Contains(search.ToLower()));
            //}
            //if (categoryId != null)
            //{
            //    query = query.Where(x => x.CategoryId == categoryId);
            //}
            //if (manufacturerIds != null && manufacturerIds.Any())
            //{
            //    query = query.Where(x => manufacturerIds.Contains(x.ManufacturerId));
            //}

            //switch (orderBy)
            //{
            //    case OrderByEnum.NameAsc:
            //        query = query.OrderBy(x => x.Name);
            //        break;
            //    case OrderByEnum.NameDesc:
            //        query = query.OrderByDescending(x => x.Name);
            //        break;
            //    case OrderByEnum.PriceAsc:
            //        query = query.OrderBy(x => x.Price);
            //        break;
            //    case OrderByEnum.PriceDesc:
            //        query = query.OrderByDescending(x => x.Price);
            //        break;
            //}

            List<Customer> customers = query.Page(page, count).ToList();

            return new Page<Customer>() { Items = customers, Total = query.Count(), CurrentPage = page, PageSize = count };
        }

        public int? Login(string email, string password)
        {
            return _context.Customers.FirstOrDefault(x => x.Email == email && x.Password == password)?.CustomerId;
        }

        public void AddCustomer(CustomerDTO customer)
        {
            if (_context.Customers.Any(x => x.Email == customer.Email))
            {
                return;
            }

            _context.Customers.Add(new Customer { Name = customer.Name, Email = customer.Email, Address = customer.Address, Password = customer.Password });
            _context.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            if (!_context.Customers.Any(x => x.CustomerId == customer.CustomerId))
            {
                return;
            }

            _context.Update(customer);
            _context.SaveChanges();
        }

        public void DisableCustomer(int customerId)
        {
            Customer? customer = _context.Customers.FirstOrDefault(x => x.CustomerId == customerId);

            if (customer == null)
                return;

            customer.Disabled = !customer.Disabled;
            _context.SaveChanges();
        }
    }
}
