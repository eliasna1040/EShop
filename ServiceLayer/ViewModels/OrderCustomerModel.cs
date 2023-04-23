using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels
{
    public class OrderCustomerModel
    {
        public int? CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public bool? Admin { get; set; }
        public bool? Disabled { get; set; }

        public OrderCustomerModel(Customer customer)
        {
            CustomerId = customer.CustomerId;
            Name = customer.Name;
            Email = customer.Email;
            Password = customer.Password;
            Address = customer.Address;
            Admin = customer.Admin;
            Disabled = customer.Disabled;
        }
    }
}
