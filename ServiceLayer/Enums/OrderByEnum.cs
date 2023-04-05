using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Enums
{
    public enum OrderByEnum
    {
        [Display(Name = "Titel stigende")]
        NameAsc = 1,
        [Display(Name = "Titel faldende")]
        NameDesc = 2,
        [Display(Name = "Pris stigende")]
        PriceAsc = 3,
        [Display(Name = "Pris faldende")]
        PriceDesc = 4,
    }
}
