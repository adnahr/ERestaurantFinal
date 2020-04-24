using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restoran.models;

namespace Restoran.Controllers
{
    [Route("/meals")]
    [ApiController]
    [Authorize]
    public class MealsController : ControllerBase
    {
        private readonly RestoranDBContext _context;

        public MealsController(RestoranDBContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Meal>>> Getmeals()
        {
            return await _context.meals.ToListAsync();
        }

        
        [HttpGet]
        [Route("/meals/recipes")]
        [AllowAnonymous]
        public ActionResult<IQueryable<Meal>> GetInforMeal()
        {
            return Ok(_context.meals.Include(m => m.Recipe).Include(m => m.specialOffers).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetMeal(int id)
        {
            var meal = await _context.meals.FindAsync(id);

            if (meal == null)
            {
                return NotFound();
            }

            return meal;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal(int id, Meal meal)
        {
            if (id != meal.MealId)
            {
                return BadRequest();
            }

            _context.Entry(meal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
        [HttpPost]
        public async Task<ActionResult<Meal>> PostMeal(Meal meal)
        {
            _context.meals.Add(meal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeal", new { id = meal.MealId }, meal);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Meal>> DeleteMeal(int id)
        {
            var meal = await _context.meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            _context.meals.Remove(meal);
            await _context.SaveChangesAsync();

            return meal;
        }

        private bool MealExists(int id)
        {
            return _context.meals.Any(e => e.MealId == id);
        }
    }
}
