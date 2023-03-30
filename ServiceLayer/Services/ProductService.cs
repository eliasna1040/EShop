using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;
using ServiceLayer.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly EShopContext _context;

        public ProductService(EShopContext context)
        {
            _context = context;
        }

        public void AddProduct(ProductDTO product)
        {
            _context.Products.Add(new Product { Name = product.Name, CategoryId = product.CategoryId, ManufacturerId = product.ManufacturerId, Price = product.Price, Description = product.Description });
            _context.SaveChanges();
        }

        public List<Product> GetProducts(int page, int count, string? search = null, int? categoryId = null, int? manufacturerId = null)
        {
            IQueryable<Product> query = _context.Products.Include(x => x.Manufacturer).Include(x => x.Category);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Manufacturer.Name.ToLower().Contains(search.ToLower()));
            }
            if (categoryId != null)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }
            if (manufacturerId != null)
            {
                query = query.Where(x => x.ManufacturerId == manufacturerId);
            }

            return query.Page(page, count).AsNoTracking().ToList();
        }

        public Product? GetProduct(int productId)
        {
            return _context.Products.Include(x => x.Manufacturer).Include(x => x.Category).AsNoTracking().FirstOrDefault(x => x.ProductId == productId);
        }

        public void EditProduct(Product newProduct)
        {
            Product? product = _context.Products.AsNoTracking().FirstOrDefault(x => x.ProductId == newProduct.ProductId);
            if (product == null)
                return;

            product = newProduct;
            _context.Entry(product).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void DisableProduct(int productId)
        {
            Product? product = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product == null)
                return;

            product.Disabled = !product.Disabled;

            _context.SaveChanges();
        }
    }
}
