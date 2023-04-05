using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ManufacturerFilter
    {
        public int ManufactureId { get; set; }
        public string ManufacturerName { get; set; }
        public bool Enabled { get; set; } = false;
    }
}
