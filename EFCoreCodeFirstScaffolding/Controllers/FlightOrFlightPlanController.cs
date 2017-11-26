using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFCoreCodeFirstScaffolding.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstScaffolding.Controllers
{
    [Produces("application/json")]
    [Route("api/FlightOrFlightPlan")]
    public class FlightOrFlightPlanController : Controller
    {
        private readonly EFCoreContext _context;

        public FlightOrFlightPlanController(EFCoreContext context)
        {
            _context = context;
        }


        //For some weird reason to get data from a proc or view you need to define a DbSet object to be the container, that you may then obtain data from.
        //It would be possible to potentially get data from multiple tables and do the joins on the front end.  However this is potentially very inefficient
        //when compared to a highly optimized procedure.

        // GET: api/FlightOrFlightPlan
        [HttpGet]
        public async Task<IEnumerable<pGetFlightOrFlightPlanResult>> GetAircraft() => await _context.pGetFlightOrFlightPlanResult.FromSql("pGetFlightOrFlightPlan @p0, @p1, @p2", parameters: new[] { "Flight", null, null }).ToListAsync();
    }
}