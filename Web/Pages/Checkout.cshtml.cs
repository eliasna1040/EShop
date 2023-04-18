using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceLayer.DTOs;
using ServiceLayer.Services;
using Web.ExtensionMethods;
using Web.JsonObjects;
using Web.Models;

namespace Web.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public CheckOutCard CheckOutCard { get; set; }
        [BindProperty]
        public CheckOutMP CheckOutMP { get; set; }

        [BindProperty]
        public string PaymentMethod { get; set; }

        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public CheckoutModel(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.MarkFieldsAsSkipped(PaymentMethod == "Mobilepay" ? nameof(CheckOutMP) : nameof(CheckOutCard)).IsValid)
            {
                return Page();
            }

            List<OrderProductDTO> orderProducts = new();
            string? cookie = HttpContext.Request.Cookies["Products"];

            if (cookie != null)
            {
                foreach (BasketJson item in JsonConvert.DeserializeObject<List<BasketJson>>(cookie))
                {
                    Product? product = _productService.GetProduct(item.ProductId);
                    if (product != null)
                    {
                        orderProducts.Add(new OrderProductDTO { ProductId = product.ProductId, Amount = item.Amount });
                    }
                }
            }

            if (orderProducts.Any())
            {
                _orderService.CreateOrder(new OrderDTO { CustomerId = HttpContext.Session.GetInt32("login").Value, OrdersProducts = orderProducts });
            }

            HttpContext.Response.Cookies.Delete("Products");

            return RedirectToPage("Index");
        }
    }
}
