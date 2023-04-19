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

        public IActionResult OnGet(int currentPage = 1, int pageSize = 10)
        {
            if (!HttpContext.Session.GetInt32("IsAdmin").HasValue)
            {
                return Redirect("~/");
            }

            Customers = _customerService.GetCustomers(currentPage, pageSize);
            return Page();
        }

        public IActionResult OnPostAdd()
        {
            if (!HttpContext.Session.GetInt32("IsAdmin").HasValue)
            {
                return Redirect("~/");
            }

            if (ModelState.IsValid)
            {
                _customerService.AddCustomer(CustomerDTO);
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDisable()
        {
            if (!HttpContext.Session.GetInt32("IsAdmin").HasValue)
            {
                return Redirect("~/");
            }

            _customerService.DisableCustomer(CustomerId);
            return RedirectToPage();
        }
    }
}
