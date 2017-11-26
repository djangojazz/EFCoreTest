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
        public async Task<IEnumerable<Aircraft>> GetAircraft()
        {
            //This may be advantageous if I want to get data, close the connection and dispose of the context.  In larger situations this is more common
            //in my experience and it is potential over kill in a small application but just FYI.  The connection for this example should be fine

            //Use this methodology when connections are at a premium in a high contact high transaction environment.
            //using (var context = new EFCoreContext())
            //{
            //    ...Do work here with contextual operations
            //}
            
            return await _context.Aircraft.Include(x => x.CreatedBy).Include(x => x.ModifiedBy).ToListAsync();
        }

        // GET: api/Aircraft/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAircraft([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aircraft = await _context.Aircraft.Include(x => x.CreatedBy).Include(x => x.ModifiedBy).SingleOrDefaultAsync(m => m.AircraftId == id);

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

            var existing = _context.Aircraft
                .Include(x => x.CreatedBy)
                .Include(x => x.ModifiedBy)
                .SingleOrDefault(x => x.AircraftId == id);

            if (existing == null) 
            {
                return BadRequest();
            }
            
            try
            {
                if(existing.AircraftName == aircraft.AircraftName && existing.ModifiedBy.UserId == aircraft?.ModifiedBy?.UserId)
                {
                    return BadRequest("Changes are exactly the same");
                }

                existing.AircraftName = aircraft.AircraftName;
                existing.ModifiedBy = GetUserFromId(aircraft?.ModifiedBy?.UserId ?? existing.ModifiedBy.UserId);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException db)
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
            //I don't want the Created By to be required in the model but in the controller for a new object it shold be
            if (!ModelState.IsValid && aircraft.CreatedBy == null)
            {
                return BadRequest(ModelState);
            }

            //I need to handle the traversing manually of EF Core addition.  EF and controllers are good at doing basic vanilla objects.
            //They typically cannot handle an object within an object reference as it blows up on misunderstanding trying to insert the object
            //versus just referencing it.  I prefer the reference method as it helps on getting objects later, although during inserts you 
            //to be aware of this.
            
            try
            {
                Aircraft newAircraft = new Aircraft(aircraft.AircraftName, GetUserFromId(aircraft?.CreatedBy?.UserId ?? 1), GetUserFromId(aircraft?.CreatedBy?.UserId ?? 1));
                _context.Aircraft.Add(newAircraft);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetAircraft", new { id = _context.Aircraft.SingleOrDefault(x => x.AircraftName == aircraft.AircraftName)?.AircraftId ?? 1 }, aircraft);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Users GetUserFromId(int userId) => _context.Users.FirstOrDefault(x => x.UserId == userId);

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