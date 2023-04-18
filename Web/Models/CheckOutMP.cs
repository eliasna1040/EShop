using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CheckOutMP
    {
        [Required]
        public string PhoneNumber { get; set; }
    }
}
