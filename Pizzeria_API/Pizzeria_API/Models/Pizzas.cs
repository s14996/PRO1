using System;
using System.Collections.Generic;

namespace Pizzeria_API.Models
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            OrderItems = new HashSet<OrderItems>();
            PizzasIngridients = new HashSet<PizzasIngridients>();
            SpecialOffers = new HashSet<SpecialOffers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PrepareTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual ICollection<PizzasIngridients> PizzasIngridients { get; set; }
        public virtual ICollection<SpecialOffers> SpecialOffers { get; set; }
    }
}
