using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels
{
    public class OrderProductModel
    {
        public int? Amount { get; set; }
        public ProductModel? Product { get; set; }

        public OrderProductModel(Product product, int amount)
        {
            Product = new ProductModel(product);
            Amount = amount;
        }
    }
}
