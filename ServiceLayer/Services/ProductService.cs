using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;
using ServiceLayer.Enums;
using ServiceLayer.ExtensionMethods;
using ServiceLayer.ViewModels;
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

        public ProductModel AddProduct(ProductDTO product, byte[] imageBytes)
        {
            Product addedProduct = new Product
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                ManufacturerId = product.ManufacturerId,
                Price = product.Price,
                Description = product.Description,
                Image = imageBytes != null ? new Image { ImageData = imageBytes} : null
            };
            _context.Products.Add(addedProduct);

            _context.SaveChanges();
            _context.Entry(addedProduct).Reload();
            _context.Entry(addedProduct).Reference(x => x.Category).Load();
            _context.Entry(addedProduct).Reference(x => x.Manufacturer).Load();
            return new ProductModel(addedProduct);
        }

        public Page<ProductModel> GetProducts(int page = 1, int count = 10, string? search = null, int? categoryId = null, int[]? manufacturerIds = null, OrderByEnum? orderBy = OrderByEnum.NameAsc)
        {
            IQueryable<Product> query = _context.Products.Include(x => x.Manufacturer)
                                                         .Include(x => x.Category)
                                                         .Include(x => x.Image)
                                                         .AsNoTracking();

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

            return new Page<ProductModel>() { Items = query.Page(page, count).Select(x => new ProductModel(x)).ToList(), Total = query.Count(), CurrentPage = page, PageSize = count };
        }

        public ProductModel? GetProduct(int productId)
        {
            return _context.Products.Where(x => x.ProductId == productId)
                                    .Include(x => x.Manufacturer)
                                    .Include(x => x.Category)
                                    .Include(x => x.Image)
                                    .AsNoTracking()
                                    .Select(x => new ProductModel(x))
                                    .FirstOrDefault();
        }

        public ProductModel? EditProduct(int id, JsonPatchDocument<Product> newProduct)
        {
            Product? product = _context.Products.Include(x => x.Manufacturer)
                                                .Include(x => x.Category)
                                                .FirstOrDefault(x => x.ProductId == id);
            if (product == null)
                return null;

            newProduct.ApplyTo(product);
            
            _context.Products.Update(product);

            _context.SaveChanges();
            return new ProductModel(product);
        }

        public ProductModel? DisableProduct(int productId)
        {
            Product? product = _context.Products.Include(x => x.Manufacturer)
                                                .Include(x => x.Category)
                                                .FirstOrDefault(x => x.ProductId == productId);
            if (product == null)
                return null;

            product.Disabled = !product.Disabled;

            _context.SaveChanges();

            return new ProductModel(product);
        }
    }
}
