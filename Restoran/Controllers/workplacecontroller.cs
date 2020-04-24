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
    [Route("/workplace")]
    [ApiController]
    public class WorkPlacesController : ControllerBase
    {
        private readonly RestoranDBContext _context;

        public WorkPlacesController(RestoranDBContext context)
        {
            _context = context;
        }

        // GET: api/WorkPlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkPlace>>> GetworkPlaces()
        {
            return await _context.workPlaces.ToListAsync();
        }

        // GET: api/WorkPlaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkPlace>> GetWorkPlace(int id)
        {
            var workPlace = await _context.workPlaces.FindAsync(id);

            if (workPlace == null)
            {
                return NotFound();
            }

            return workPlace;
        }

        // PUT: api/WorkPlaces/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkPlace(int id, WorkPlace workPlace)
        {
            if (id != workPlace.WPId)
            {
                return BadRequest();
            }

            _context.Entry(workPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkPlaceExists(id))
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

        // POST: api/WorkPlaces
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WorkPlace>> PostWorkPlace(WorkPlace workPlace)
        {
            _context.workPlaces.Add(workPlace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkPlace", new { id = workPlace.WPId }, workPlace);
        }

        // DELETE: api/WorkPlaces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkPlace>> DeleteWorkPlace(int id)
        {
            var workPlace = await _context.workPlaces.FindAsync(id);
            if (workPlace == null)
            {
                return NotFound();
            }

            _context.workPlaces.Remove(workPlace);
            await _context.SaveChangesAsync();

            return workPlace;
        }

        private bool WorkPlaceExists(int id)
        {
            return _context.workPlaces.Any(e => e.WPId == id);
        }
    }
}
