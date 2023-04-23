using DataLayer.Entities;
using Microsoft.AspNetCore.JsonPatch;
using ServiceLayer.DTOs;
using ServiceLayer.ViewModels;

namespace ServiceLayer.Services
{
    public interface ICustomerService
    {
        CustomerModel? AddCustomer(CustomerDTO customer);
        CustomerModel? DisableCustomer(int customerId);
        CustomerModel? EditCustomer(int id, JsonPatchDocument<Customer> newCustomer);
        CustomerModel? GetCustomer(int id);
        Page<CustomerModel> GetCustomers(int page, int count);
        UserDTO? Login(string email, string password);
    }
}