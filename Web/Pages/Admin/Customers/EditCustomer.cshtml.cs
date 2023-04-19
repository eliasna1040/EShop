using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Services;

namespace Web.Pages.Admin.Customers
{
    public class EditCustomerModel : PageModel
    {
        [BindProperty]
        public Customer? Customer { get; set; }

        private readonly ICustomerService _customerService;

        public EditCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult OnGet(int customerId)
        {
            if (!HttpContext.Session.GetInt32("IsAdmin").HasValue)
            {
                return Redirect("~/");
            }

            Customer = _customerService.GetCustomer(customerId);

            if (Customer == null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!HttpContext.Session.GetInt32("IsAdmin").HasValue)
            {
                return Redirect("~/");
            }

            if (ModelState.IsValid)
            {
                _customerService.EditCustomer(Customer!);
            }

            return RedirectToPage("Index");
        }
    }
}
