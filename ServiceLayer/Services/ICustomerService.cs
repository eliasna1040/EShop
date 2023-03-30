using DataLayer.Entities;
using ServiceLayer.DTOs;

namespace ServiceLayer.Services
{
    public interface ICustomerService
    {
        void AddCustomer(CustomerDTO customer);
        Customer? GetCustomer(int id);
        int? Login(string email, string password);
    }
}