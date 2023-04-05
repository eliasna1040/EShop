using DataLayer.Entities;
using ServiceLayer.DTOs;
using ServiceLayer.Enums;

namespace ServiceLayer.Services
{
    public interface IProductService
    {
        void AddProduct(ProductDTO product);
        void DisableProduct(int productId);
        void EditProduct(Product newProduct);
        Product? GetProduct(int productId);
        List<Product> GetProducts(int page, int count, string? search = null, int? categoryId = null, int[]? manufacturerIds = null, OrderByEnum? orderBy = OrderByEnum.NameAsc);
    }
}