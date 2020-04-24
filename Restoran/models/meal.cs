using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class Meal
    {

        [Key]
        public int MealId { get; set; }

        [Required]
        public int Price { get; set; }

        public int SpecialOffer { get; set; } //percentage

        public DateTime? OfferStart { get; set; }

        public DateTime? OfferEnd { get; set; }

        public Category Category { get; set; }

        public List<Recipe> Recipe { get; set; }

        public List<UnitMenu> unitMenus { get; set; }

        public List<SpecialOffer>? specialOffers { get; set; }

        public List<BillMeal> BillMeals { get; set; }

        public String Path { get; set; }

        public String Image { get; set; }
        public List<OrderMeal> OrderMeals { get; set; }
    }
}
