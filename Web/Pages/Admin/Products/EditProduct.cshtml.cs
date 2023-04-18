using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Services;
using Web.ExtensionMethods;

namespace Web.Pages.Admin.Products
{
    public class EditProductModel : PageModel
    {
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Manufacturers { get; set; }

        [BindProperty]
        public Product? Product { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

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
            if (ModelState.MarkFieldsAsSkipped(new string[] {nameof(Image), nameof(Product.Manufacturer), nameof(Product.Category), nameof(Product.OrdersProducts)}).IsValid)
            {
                using MemoryStream ms = new MemoryStream();
                if (Image != null)
                {
                    Image.CopyTo(ms);
                    Product.Image = new Image { ImageData = ms.ToArray() };
                }
                _productService.EditProduct(Product!);
            }

            return RedirectToPage("Index");
        }
    }
}
