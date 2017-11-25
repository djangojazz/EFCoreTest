using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreCodeFirstScaffolding.Models;

namespace EFCoreCodeFirstScaffolding.Controllers
{
    [Produces("application/json")]
    [Route("api/Aircraft")]
    public class AircraftController : Controller
    {
        //Invoking a dependency injection manner in the controller is fine provided the lifetime is acceptable.  In a larger environment of many controllers
        //you may get a problem with a larger set of connections open even when not being used.
        private readonly EFCoreContext _context;

        public AircraftController(EFCoreContext context)
        {
            _context = context;
        }

        // GET: api/Aircraft
        [HttpGet]
        public IEnumerable<Aircraft> GetAircraft()
        {
            //This may be advantageous if I want to get data, close the connection and dispose of the context.  In larger situations this is more common
            //in my experience and it is potential over kill in a small application but just FYI.  The connection 
            using (var context = new EFCoreContext())
            {
                var aircraft = context.Aircraft.ToList();
                return aircraft;
            }

            //return _context.Aircraft.ToList();
        }

        // GET: api/Aircraft/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAircraft([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aircraft = await _context.Aircraft.SingleOrDefaultAsync(m => m.AircraftId == id);

            if (aircraft == null)
            {
                return NotFound();
            }

            return Ok(aircraft);
        }

        // PUT: api/Aircraft/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraft([FromRoute] int id, [FromBody] Aircraft aircraft)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aircraft.AircraftId)
            {
                return BadRequest();
            }

            _context.Entry(aircraft).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftExists(id))
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

        // POST: api/Aircraft
        [HttpPost]
        public async Task<IActionResult> PostAircraft([FromBody] Aircraft aircraft)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Aircraft.Add(aircraft);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAircraft", new { id = aircraft.AircraftId }, aircraft);
        }

        // DELETE: api/Aircraft/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraft([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aircraft = await _context.Aircraft.SingleOrDefaultAsync(m => m.AircraftId == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            _context.Aircraft.Remove(aircraft);
            await _context.SaveChangesAsync();

            return Ok(aircraft);
        }

        private bool AircraftExists(int id)
        {
            return _context.Aircraft.Any(e => e.AircraftId == id);
        }
    }
}