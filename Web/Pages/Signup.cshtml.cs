using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.DTOs;
using ServiceLayer.Services;
using System.ComponentModel.DataAnnotations;

namespace Web.Pages
{
    public class SignupModel : PageModel
    {
        [BindProperty, Required]
        public string Name { get; set; }
        [BindProperty, Required]
        public string Email { get; set; }
        [BindProperty, Required]
        public string Address { get; set; }
        [BindProperty, Required]
        public string Password { get; set; }
        [BindProperty, Compare("Password")]
        public string ConfirmPassword { get; set; }

        private readonly ICustomerService _customerService;

        public SignupModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _customerService.AddCustomer(new CustomerDTO { Address = Address, Email = Email, Name = Name, Password = Password });
                return RedirectToPage("Login");
            }
            return Page();
        }
    }
}
