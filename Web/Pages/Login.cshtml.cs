using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.DTOs;
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
        [BindProperty]
        public string? ReturnPage { get; set; }

        private readonly ICustomerService _customerService;

        public LoginModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult OnGet(string? returnPage)
        {
            if (HttpContext.Session.GetInt32("login").HasValue)
            {
                return RedirectToPage("Index");
            }
            ReturnPage = returnPage;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                UserDTO user = _customerService.Login(Email, Password);
                if (user.Id.HasValue)
                {
                    HttpContext.Session.SetInt32("login", user.Id.Value);
                    if (user.IsAdmin)
                    {
                        HttpContext.Session.SetInt32("IsAdmin", 1);
                    }
                    return RedirectToPage(ReturnPage ?? "Index");
                }
            }
            return Page();
        }
    }
}
