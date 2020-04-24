using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restoran.models;

namespace Restoran.Controllers
{
    [Route("/menus")]
    [ApiController]
    public class UnitMenusController : ControllerBase
    {
        private readonly RestoranDBContext _context;

        public UnitMenusController(RestoranDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitMenu>>> GetunitMenus()
        {
            return await _context.unitMenus.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitMenu>> GetUnitMenu(int id)
        {
            var unitMenu = await _context.unitMenus.FindAsync(id);

            if (unitMenu == null)
            {
                return NotFound();
            }

            return unitMenu;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitMenu(int id, UnitMenu unitMenu)
        {
            if (id != unitMenu.MealId)
            {
                return BadRequest();
            }

            _context.Entry(unitMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitMenuExists(id))
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
        public async Task<ActionResult<UnitMenu>> PostUnitMenu(UnitMenu unitMenu)
        {
            _context.unitMenus.Add(unitMenu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitMenuExists(unitMenu.MealId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnitMenu", new { id = unitMenu.MealId }, unitMenu);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<UnitMenu>> DeleteUnitMenu(int id)
        {
            var unitMenu = await _context.unitMenus.FindAsync(id);
            if (unitMenu == null)
            {
                return NotFound();
            }

            _context.unitMenus.Remove(unitMenu);
            await _context.SaveChangesAsync();

            return unitMenu;
        }

        private bool UnitMenuExists(int id)
        {
            return _context.unitMenus.Any(e => e.MealId == id);
        }
    }
}
