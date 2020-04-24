using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public TimeSpan Time { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public RestaurantUnit RestaurantUnit { get; set; }

        public int BillFK { get; set; }
        public Bill Bill { get; set; }

        public List<OrderMeal> OrderMeals { get; set; }

        public User User { get; set; }
    }
}
