using System;
using System.Collections.Generic;

namespace Pizzeria_API.Models
{
    public partial class Ingridients
    {
        public Ingridients()
        {
            OrderItemsIngridients = new HashSet<OrderItemsIngridients>();
            PizzasIngridients = new HashSet<PizzasIngridients>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<OrderItemsIngridients> OrderItemsIngridients { get; set; }
        public virtual ICollection<PizzasIngridients> PizzasIngridients { get; set; }
    }
}
