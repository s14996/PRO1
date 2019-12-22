using System;
using System.Collections.Generic;

namespace Pizzeria_API.Models
{
    public partial class OrderItems
    {
        public OrderItems()
        {
            OrderItemsIngridients = new HashSet<OrderItemsIngridients>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Pizzas Pizza { get; set; }
        public virtual ICollection<OrderItemsIngridients> OrderItemsIngridients { get; set; }
    }
}
