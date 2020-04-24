using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class OrderMeal
    {
        public int Col { get; set; } //quantity

        public int Price { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
