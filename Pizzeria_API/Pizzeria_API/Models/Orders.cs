using System;
using System.Collections.Generic;

namespace Pizzeria_API.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public DateTime OrderDate { get; set; }
        public string DiscountCode { get; set; }
        public int StatusId { get; set; }

        public virtual DiscountCodes DiscountCodeNavigation { get; set; }
        public virtual Restaurants Restaurant { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
