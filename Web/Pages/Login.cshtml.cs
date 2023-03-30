using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Services;
using System.ComponentModel.DataAnnotations;

namespace Web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty, Required]
        public string Email { get; set; }
        [BindProperty, Required]
        public string Password { get; set; }

        private readonly ICustomerService _customerService;

        public LoginModel(ICustomerService customerService)
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
                int? id = _customerService.Login(Email, Password);
                if (id.HasValue)
                {
                    HttpContext.Session.SetInt32("login", id.Value);
                    return RedirectToPage("Index");
                }
            }
            return Page();
        }
    }
}
