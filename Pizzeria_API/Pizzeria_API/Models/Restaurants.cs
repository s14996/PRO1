using System;
using System.Collections.Generic;

namespace Pizzeria_API.Models
{
    public partial class Restaurants
    {
        public Restaurants()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
