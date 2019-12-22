using System;
using System.Collections.Generic;

namespace Pizzeria_API.Models
{
    public partial class SpecialOffers
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public double Price { get; set; }
        public bool? IsActive { get; set; }

        public virtual Pizzas Pizza { get; set; }
    }
}
