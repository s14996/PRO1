using System;
using System.Collections.Generic;

namespace Pizzeria_API.Models
{
    public partial class PizzasIngridients
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int IngridientId { get; set; }
        public int Quantity { get; set; }

        public virtual Ingridients Ingridient { get; set; }
        public virtual Pizzas Pizza { get; set; }
    }
}
