using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace ServiceLayer.ViewModels
{
    public class CustomerModel
    {
        public int? CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public bool? Admin { get; set; }
        public bool? Disabled { get; set; }
        public List<CustomerOrderModel>? Orders { get; set; }

        public CustomerModel(Customer customer)
        {
            CustomerId = customer.CustomerId;
            Name = customer.Name;
            Email = customer.Email;
            Password = customer.Password;
            Address = customer.Address;
            Admin = customer.Admin;
            Disabled = customer.Disabled;
            Orders = customer.Orders?.Select(x => new CustomerOrderModel(x)).ToList();
        }
    }
}
