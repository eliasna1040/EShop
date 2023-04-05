using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Services;
using Newtonsoft.Json;
using Web.JsonObjects;
using Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; }

        public List<SelectListItem> ManufacturersFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public int[] ManufacturerIds { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }


        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;
        private readonly IManufacturerService _manufacturerService;

        public IndexModel(ILogger<IndexModel> logger, IProductService productService, IManufacturerService manufacturerService)
        {
            _logger = logger;
            _productService = productService;
            _manufacturerService = manufacturerService;
        }

        public void OnGet(string? search = null, int? categoryId = null, int[]? manufacturerIds = null)
        {
            Search = search;
            CategoryId = categoryId;
            Products = _productService.GetProducts(1, 20, search, categoryId, manufacturerIds);
            if (manufacturerIds != null)
            {
                ManufacturersFilter = _manufacturerService.GetManufacturersFromSearch(search).Select(x => new SelectListItem { Value = x.ManufacturerId.ToString(), Text = x.Name, Selected = manufacturerIds.Contains(x.ManufacturerId) }).ToList();
            }
        }

        public IActionResult OnPostAddProduct(int productId)
        {
            string? cookie = Request.Cookies["Products"];
            List<BasketJson> basket = new List<BasketJson>();
            if (cookie != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketJson>>(Request.Cookies["Products"]);
            }

            basket.Add(new BasketJson { ProductId = productId });
            Response.Cookies.Append("Products", JsonConvert.SerializeObject(basket), new CookieOptions() { Expires = DateTime.Now.AddDays(30) });

            return RedirectToPage();
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("Index", new { search = Search, manufacturerIds = ManufacturerIds, categoryId = CategoryId });
        }
    }
}