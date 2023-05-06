using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class OrderModel
    {
        public int? OrderId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public bool? Disabled { get; set; }

        public OrderCustomerModel? Customer { get; set; }
        public List<OrderProductModel>? Products { get; set; }
    }
}
