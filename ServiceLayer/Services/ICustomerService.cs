using DataLayer.Entities;
using ServiceLayer.DTOs;

namespace ServiceLayer.Services
{
    public interface ICustomerService
    {
        void AddCustomer(CustomerDTO customer);
        void DisableCustomer(int customerId);
        void EditCustomer(Customer customer);
        Customer? GetCustomer(int id);
        Page<Customer> GetCustomers(int page, int count);
        UserDTO Login(string email, string password);
    }
}