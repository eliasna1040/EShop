using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.DTOs;
using ServiceLayer.Services;
using System.ComponentModel.DataAnnotations;

namespace Web.Pages.Admin.Customers
{
    public class IndexModel : PageModel
    {
        public Page<Customer> Customers { get; set; }

        [BindProperty]
        public CustomerDTO CustomerDTO { get; set; }

        [BindProperty]
        public int CustomerId { get; set; }

        private readonly ICustomerService _customerService;

        public IndexModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void OnGet(int currentPage = 1, int pageSize = 10)
        {
            Customers = _customerService.GetCustomers(currentPage, pageSize);
        }

        public IActionResult OnPostAdd()
        {
            if (ModelState.IsValid)
            {
                _customerService.AddCustomer(CustomerDTO);
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDisable()
        {
            _customerService.DisableCustomer(CustomerId);
            return RedirectToPage();
        }
    }
}
