using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }

        public TimeSpan Time { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int Price { get; set; }

        public int PDV { get; set; } //percentage

        public int TotalAmouth { get; set; }

        public RestaurantUnit RestaurantUnit { get; set; }

        public List<BillMeal> BillMeals { get; set; }

        public Order Order { get; set; }

        public User User { get; set; }
    }
}
