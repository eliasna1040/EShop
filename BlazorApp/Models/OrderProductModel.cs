using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class OrderProductModel
    {
        public int? Amount { get; set; }
        public ProductModel? Product { get; set; }
    }
}
