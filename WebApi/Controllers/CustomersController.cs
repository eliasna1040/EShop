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

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerDTO customer)
        {
            try
            {
                return Ok(_customerService.AddCustomer(customer));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public IActionResult EditCustomer(int id, [FromBody] JsonPatchDocument<Customer> newCustomer)
        {
            try
            {
                return Ok(_customerService.EditCustomer(id, newCustomer));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{email}/login")]
        public IActionResult Login(string email, string password)
        {
            UserDTO? user = _customerService.Login(email, password);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
    }
}
