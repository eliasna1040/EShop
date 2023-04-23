using DataLayer.Entities;
using Microsoft.AspNetCore.JsonPatch;
using ServiceLayer.DTOs;
using ServiceLayer.Enums;
using ServiceLayer.ViewModels;

namespace ServiceLayer.Services
{
    public interface IProductService
    {
        ProductModel AddProduct(ProductDTO product, byte[]? byteImage);
        ProductModel? DisableProduct(int productId);
        ProductModel? EditProduct(int id, JsonPatchDocument<Product> newProduct);
        ProductModel? GetProduct(int productId);
        Page<ProductModel> GetProducts(int page, int count, string? search = null, int? categoryId = null, int[]? manufacturerIds = null, OrderByEnum? orderBy = OrderByEnum.NameAsc);
    }
}