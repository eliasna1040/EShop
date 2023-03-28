using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
