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
    [Route("api/specialOffer")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly RestoranDBContext _context;

        public SpecialOffersController(RestoranDBContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialOffer>>> GetspecialOffers()
        {
            return await _context.specialOffers.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialOffer>> GetSpecialOffer(int id)
        {
            var specialOffer = await _context.specialOffers.FindAsync(id);

            if (specialOffer == null)
            {
                return NotFound();
            }

            return specialOffer;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialOffer(int id, SpecialOffer specialOffer)
        {
            if (id != specialOffer.SpecOfferId)
            {
                return BadRequest();
            }

            _context.Entry(specialOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialOfferExists(id))
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
        public async Task<ActionResult<SpecialOffer>> PostSpecialOffer(SpecialOffer specialOffer)
        {
            _context.specialOffers.Add(specialOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialOffer", new { id = specialOffer.SpecOfferId }, specialOffer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecialOffer>> DeleteSpecialOffer(int id)
        {
            var specialOffer = await _context.specialOffers.FindAsync(id);
            if (specialOffer == null)
            {
                return NotFound();
            }

            _context.specialOffers.Remove(specialOffer);
            await _context.SaveChangesAsync();

            return specialOffer;
        }

        private bool SpecialOfferExists(int id)
        {
            return _context.specialOffers.Any(e => e.SpecOfferId == id);
        }
    }
}
