using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restoran.DTO;
using Restoran.models;

namespace Restoran.Controllers
{
    [Route("/restaurantUnits")]
    [ApiController]
    [EnableCors ("RestaurantPolicy")]
    public class RestaurantUnitsController : ControllerBase
    {
        private readonly RestoranDBContext _context;

        public RestaurantUnitsController(RestoranDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/restaurantUnit/restaurant/{id}")]
        public ActionResult<IEnumerable<RestaurantUnit>> GetrestaurantUnits(int id)
        {
            return _context.restaurantUnits.Where(r => r.Restaurant.RestaurantId == id).ToList();
        }

        [HttpGet]
        [Route("/aboutRestaurant")]
        public ActionResult<IEnumerable<RestaurantUnit>> GetRestataurantInfo()
        {
            return Ok(_context.restaurantUnits.Include(m => m.Location).ToList());
            //return _context.restaurantUnits.FromSqlRaw("EXEC aboutRestarurantUnits").ToList();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantUnit>> GetRestaurantUnit(int id)
        {
            var restaurantUnit = await _context.restaurantUnits.FindAsync(id);

            if (restaurantUnit == null)
            {
                return NotFound();
            }

            return restaurantUnit;
        }

 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantUnit(int id, RUDTO restaurantUnit)
        {
            
            var location = _context.locations.Where(l => l.id == restaurantUnit.LocationId).SingleOrDefault();
            var restaurant = _context.restaurants.Where(r => r.RestaurantId == restaurantUnit.RestaurantId).SingleOrDefault();
            var ru = new RestaurantUnit
            {
                Tel = restaurantUnit.Tel,
                EmployeeNo = restaurantUnit.EmployeeNo,
                OpeningDate = restaurantUnit.OpeningDate,
                ClosingDate = restaurantUnit.ClosingDate,
                Capacity = restaurantUnit.Capacity,
                Restaurant = restaurant,
                Location = location
            };

            _context.Entry(restaurantUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantUnitExists(id))
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
        public async Task<ActionResult<RestaurantUnit>> PostRestaurantUnit(RUDTO rUDTO)
        {
            var location = _context.locations.Where(l => l.id == rUDTO.LocationId).SingleOrDefault();
            var restaurant = _context.restaurants.Where(r => r.RestaurantId == rUDTO.RestaurantId).SingleOrDefault();
            var ru = new RestaurantUnit
            {
                Tel = rUDTO.Tel,
                EmployeeNo = rUDTO.EmployeeNo,
                OpeningDate = rUDTO.OpeningDate,
                ClosingDate = rUDTO.ClosingDate,
                Capacity = rUDTO.Capacity,
                Restaurant = restaurant,
                Location = location
            };

            _context.restaurantUnits.Add(ru);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantUnit", new { id = ru.UnitId }, ru);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<RestaurantUnit>> DeleteRestaurantUnit(int id)
        {
            var restaurantUnit = await _context.restaurantUnits.FindAsync(id);
            if (restaurantUnit == null)
            {
                return NotFound();
            }

            _context.restaurantUnits.Remove(restaurantUnit);
            await _context.SaveChangesAsync();

            return restaurantUnit;
        }

        private bool RestaurantUnitExists(int id)
        {
            return _context.restaurantUnits.Any(e => e.UnitId == id);

        }



    }
}
