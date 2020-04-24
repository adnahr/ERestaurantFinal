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
    [Route("/tablePosition")]
    [ApiController]
    public class TablePositionsController : ControllerBase
    {
        private readonly RestoranDBContext _context;

        public TablePositionsController(RestoranDBContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TablePosition>>> GettablePositions()
        {
            return await _context.tablePositions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TablePosition>> GetTablePosition(int id)
        {
            var tablePosition = await _context.tablePositions.FindAsync(id);

            if (tablePosition == null)
            {
                return NotFound();
            }

            return tablePosition;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTablePosition(int id, TablePosition tablePosition)
        {
            if (id != tablePosition.TPId)
            {
                return BadRequest();
            }

            _context.Entry(tablePosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TablePositionExists(id))
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
        public async Task<ActionResult<TablePosition>> PostTablePosition(TablePosition tablePosition)
        {
            _context.tablePositions.Add(tablePosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTablePosition", new { id = tablePosition.TPId }, tablePosition);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<TablePosition>> DeleteTablePosition(int id)
        {
            var tablePosition = await _context.tablePositions.FindAsync(id);
            if (tablePosition == null)
            {
                return NotFound();
            }

            _context.tablePositions.Remove(tablePosition);
            await _context.SaveChangesAsync();

            return tablePosition;
        }

        private bool TablePositionExists(int id)
        {
            return _context.tablePositions.Any(e => e.TPId == id);
        }
    }
}
