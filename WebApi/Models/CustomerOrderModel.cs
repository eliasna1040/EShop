using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class CustomerOrderModel
    {
        public int? OrderId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public bool? Disabled { get; set; }

        public List<OrderProductModel>? Products { get; set; }

        public CustomerOrderModel(Order order)
        {
            OrderId = order.OrderId;
            PurchaseDate = order.PurchaseDate;
            Disabled = order.Disabled;

            Products = order.OrdersProducts?.Select(x => new OrderProductModel(x.Product, x.Amount)).ToList();
        }
    }
}
