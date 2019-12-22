using System;
using System.Collections.Generic;

namespace Pizzeria_API.Models
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
