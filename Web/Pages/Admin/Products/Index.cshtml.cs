using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.DTOs;
using ServiceLayer.Services;

namespace Web.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        public Page<Product> Products { get; set; }

        public List<SelectListItem> Manufacturers { get; set; }

        public List<SelectListItem> Categories { get; set; }

        [BindProperty]
        public ProductDTO ProductDTO { get; set; }

        [BindProperty]
        public int ProductId { get; set; }

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IManufacturerService _manufacturerService;

        public IndexModel(IProductService productService, ICategoryService categoryService, IManufacturerService manufacturerService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _manufacturerService = manufacturerService;
        }

        public void OnGet(int currentPage = 1, int count = 10)
        {
            Products = _productService.GetProducts(currentPage, count);
            Manufacturers = _manufacturerService.GetManufacturers().Select(x => new SelectListItem { Text = x.Name, Value = x.ManufacturerId.ToString() }).ToList();
            Categories = _categoryService.GetCategories().Select(x => new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() }).ToList();
        }

        public IActionResult OnPostDisable()
        {
            _productService.DisableProduct(ProductId);
            return RedirectToPage();
        }

        public IActionResult OnPostAdd()
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(ProductDTO);
            }

            return RedirectToPage();
        }
    }
}
