using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Services;

namespace Web.Pages.Admin.Products
{
    public class EditProductModel : PageModel
    {
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Manufacturers { get; set; }

        [BindProperty]
        public Product? Product { get; set; }

        private readonly IManufacturerService _manufacturerService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public EditProductModel(IProductService productService, ICategoryService categoryService, IManufacturerService manufacturerService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _manufacturerService = manufacturerService;
        }

        public IActionResult OnGet(int productId)
        {
            Product = _productService.GetProduct(productId);

            if (Product == null)
            {
                return RedirectToPage("Index");
            }

            Manufacturers = _manufacturerService.GetManufacturers().Select(x => new SelectListItem { Text = x.Name, Value = x.ManufacturerId.ToString(), Selected = x.ManufacturerId == Product.ManufacturerId }).ToList();
            Categories = _categoryService.GetCategories().Select(x => new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString(), Selected = x.CategoryId == Product.CategoryId }).ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _productService.EditProduct(Product!);
            }

            return RedirectToPage("Index");
        }
    }
}
