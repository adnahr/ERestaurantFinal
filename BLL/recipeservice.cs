using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restoran.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class RecipeService
    {
        private RestoranDBContext RestoranDBContextt;
        RecipeService(RestoranDBContext ctx)
        {

            this.RestoranDBContextt = ctx;

        }
        public async Task<IEnumerable<Recipe>> getRecipes()
        {
            return await RestoranDBContextt.recipes.ToListAsync();
        }
    }

}
