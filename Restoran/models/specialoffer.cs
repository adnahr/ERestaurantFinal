using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class SpecialOffer
    {
        [Key]
        public int SpecOfferId { get; set; }

        public string Name { get; set; }

        public int Discount { get; set; } //percentage

        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
