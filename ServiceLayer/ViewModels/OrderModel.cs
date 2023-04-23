using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels
{
    public class OrderModel
    {
        public int? OrderId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public bool? Disabled { get; set; }

        public OrderCustomerModel? Customer { get; set; }
        public List<OrderProductModel>? Products { get; set; }

        public OrderModel(Order order)
        {
            OrderId = order.OrderId;
            PurchaseDate = order.PurchaseDate;
            Disabled = order.Disabled;

            Customer = new OrderCustomerModel(order.Customer);
            Products = order.OrdersProducts.Select(x => new OrderProductModel(x.Product, x.Amount)).ToList();
        }
    }
}
