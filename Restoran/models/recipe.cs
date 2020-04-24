using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class Recipe
    {
        [Key]
        public int RecpeId { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string RecipeText { get; set; }

        public int PreparationTime { get; set; } //minutes

        //public Meal Meal { get; set; }
    }
}
