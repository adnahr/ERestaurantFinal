using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class BillMeal
    {
        public int Col { get; set; } //quantity

        public int Price { get; set; }

        public int BillId { get; set; }
        public Bill Bill { get; set; }

        public int MealId { get; set; }
        public Meal Meal { get; set; }

    }
}
