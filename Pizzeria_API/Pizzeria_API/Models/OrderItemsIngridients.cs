using System;
using System.Collections.Generic;

namespace Pizzeria_API.Models
{
    public partial class OrderItemsIngridients
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int IngridientId { get; set; }
        public int Quantity { get; set; }

        public virtual Ingridients Ingridient { get; set; }
        public virtual OrderItems OrderItem { get; set; }
    }
}
