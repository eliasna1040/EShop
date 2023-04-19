using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;
using ServiceLayer.Enums;
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
            _context.Products.Add(new Product { Name = product.Name, CategoryId = product.CategoryId, ManufacturerId = product.ManufacturerId, Price = product.Price, Description = product.Description, Image = product.Image != null ? new Image { ImageData = product.Image } : null });
            _context.SaveChanges();
        }

        public Page<Product> GetProducts(int page = 1, int count = 10, string? search = null, int? categoryId = null, int[]? manufacturerIds = null, OrderByEnum? orderBy = OrderByEnum.NameAsc)
        {
            IQueryable<Product> query = _context.Products.Include(x => x.Manufacturer).Include(x => x.Category).Include(x => x.Image).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Manufacturer.Name.ToLower().Contains(search.ToLower()));
            }
            if (categoryId != null)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }
            if (manufacturerIds != null && manufacturerIds.Any())
            {
                query = query.Where(x => manufacturerIds.Contains(x.ManufacturerId));
            }

            switch (orderBy)
            {
                case OrderByEnum.NameAsc:
                    query = query.OrderBy(x => x.Name);
                    break;
                case OrderByEnum.NameDesc:
                    query = query.OrderByDescending(x => x.Name);
                    break;
                case OrderByEnum.PriceAsc:
                    query = query.OrderBy(x => x.Price);
                    break;
                case OrderByEnum.PriceDesc:
                    query = query.OrderByDescending(x => x.Price);
                    break;
            }

            return new Page<Product>() { Items = query.Page(page, count).ToList(), Total = query.Count(), CurrentPage = page, PageSize = count };
        }

        public Product? GetProduct(int productId)
        {
            return _context.Products.Include(x => x.Manufacturer).Include(x => x.Category).Include(x => x.Image).AsNoTracking().FirstOrDefault(x => x.ProductId == productId);
        }

        public void EditProduct(Product newProduct)
        {
            if (!_context.Products.Any(x => x.ProductId == newProduct.ProductId))
                return;

            _context.Products.Update(newProduct);

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
