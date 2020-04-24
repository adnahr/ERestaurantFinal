using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class UnitMenu
    {
        public int MealId { get; set; }
        public Meal AllMeals { get; set; }

        public int UnitId { get; set; }
        public RestaurantUnit AllRestaurantUnit { get; set; }


    }
}
