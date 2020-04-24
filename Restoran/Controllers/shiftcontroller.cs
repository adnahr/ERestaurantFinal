using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restoran.DTO;
using Restoran.models;

namespace Restoran.Controllers
{
    [Route("/shifts")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly RestoranDBContext _context;

        public ShiftsController(RestoranDBContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shift>>> Getshifts()
        {
            return await _context.shifts.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Shift>> GetShift(int id)
        {
            var shift = await _context.shifts.FindAsync(id);

            if (shift == null)
            {
                return NotFound();
            }

            return shift;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShift(int id, Shift shift)
        {
            if (id != shift.ShiftId)
            {
                return BadRequest();
            }

            _context.Entry(shift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftExists(id))
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
        public async Task<ActionResult<Shift>> PostShift([FromBody]ShiftDTO shiftDto)
        {
            Shift shift = new Shift
            {
                Name = shiftDto.Name,
                StartTime = new TimeSpan(shiftDto.Hours, shiftDto.Minutes, shiftDto.Seconds),
                EndTime = new TimeSpan(shiftDto.HoursEnd, shiftDto.MinutesEnd, shiftDto.SecondsEnd)
            };
            _context.shifts.Add(shift);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShift", new { id = shift.ShiftId }, shift);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shift>> DeleteShift(int id)
        {
            var shift = await _context.shifts.FindAsync(id);
            if (shift == null)
            {
                return NotFound();
            }

            _context.shifts.Remove(shift);
            await _context.SaveChangesAsync();

            return shift;
        }

        private bool ShiftExists(int id)
        {
            return _context.shifts.Any(e => e.ShiftId == id);
        }
    }
}
