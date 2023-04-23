using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Services;
using ServiceLayer.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers(int start = 1, int count = 10)
        {
            return Ok(_customerService.GetCustomers(start, count));
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            CustomerModel? customer = _customerService.GetCustomer(id);
            if (customer != null)
            {
                return Ok(customer);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerDTO customer)
        {
            CustomerModel? addedCustomer = _customerService.AddCustomer(customer);
            if (addedCustomer != null)
            {
                return Ok(addedCustomer);
            }

            return BadRequest();
        }

        [HttpPatch("{id}")]
        public IActionResult EditCustomer(int id, [FromBody]JsonPatchDocument<Customer> newCustomer)
        {
            CustomerModel? customer = _customerService.EditCustomer(id, newCustomer);
            if (customer != null)
            {
                return Ok(customer);
            }

            return BadRequest();
        }

        [HttpGet("{email}/login")]
        public IActionResult Login(string email, string password)
        {
            UserDTO? user = _customerService.Login(email, password);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest();
        }
    }
}
