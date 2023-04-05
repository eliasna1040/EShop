using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceLayer.DTOs;
using ServiceLayer.Services;
using Web.JsonObjects;

namespace Web.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public CheckoutModel(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        public IActionResult OnPost()
        {
            List<Product> products = new();
            string? cookie = HttpContext.Request.Cookies["Products"];
            if (cookie != null)
            {
                foreach (BasketJson item in JsonConvert.DeserializeObject<List<BasketJson>>(cookie))
                {
                    products.Add(_productService.GetProduct(item.ProductId));
                }
            }

            if (products.Any())
            {
                _orderService.CreateOrder(new OrderDTO { CustomerId = HttpContext.Session.GetInt32("login").Value, ProductIds = products.Select(x => x.ProductId).ToList() });
            }

            HttpContext.Response.Cookies.Delete("Products");

            return RedirectToPage("Index");
        }
    }
}
