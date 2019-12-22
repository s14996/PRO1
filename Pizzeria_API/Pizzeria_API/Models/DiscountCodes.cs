using System;
using System.Collections.Generic;

namespace Pizzeria_API.Models
{
    public partial class DiscountCodes
    {
        public DiscountCodes()
        {
            Orders = new HashSet<Orders>();
        }

        public string Code { get; set; }
        public double? Percentage { get; set; }
        public double? Amount { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
