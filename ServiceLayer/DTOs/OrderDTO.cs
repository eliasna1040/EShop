using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs
{
    public class OrderDTO
    {
        public DateTime PurchaseDate { get; set; }
        public int CustomerId { get; set; }
        public List<OrderProductDTO> OrdersProducts { get; set; }
    }
}
