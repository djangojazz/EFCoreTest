using EFCoreCodeFirstScaffolding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstScaffolding
{
    public static class DbInitializer
    {
        public static void Initialize(EFCoreContext context)
        {
            context.Database.EnsureCreated();
            
            //Only invoke seeding of data if tables do not contain data already.

            if (!context.Users.Any())
            {
                new List<Users>
                {
                    new Users("Admin"),
                    new Users("Brett")
                }
                .ForEach(x => context.Users.Add(x));
                context.SaveChanges();
            }

            var admin = context.Users.Single(x => x.UserId == 1);

            if (!context.Aircraft.Any())
            {
                new List<Aircraft>
                {
                    new Aircraft("737", admin, admin),
                    new Aircraft("747", admin, admin)
                }
                .ForEach(x => context.Aircraft.Add(x));
                context.SaveChanges();
            }

            var acs = context.Aircraft.ToList();

            if (!context.Flight.Any())
            {
                new List<Flight>
                {
                    new Flight("737", admin, admin),
                    new Flight("747", admin, admin)
                }
                .ForEach(x => context.Flight.Add(x));
                context.SaveChanges();
            }

            var fs = context.Flight.ToList();
            
            if(!context.FlightPlan.Any())
            {
                new List<FlightPlan>
                {
                    new FlightPlan("FlightPlan737-A", fs[0], admin, admin),
                    new FlightPlan("FlightPlan737-B", fs[0], admin, admin),
                    new FlightPlan("FlightPlan747-A", fs[1], admin, admin)
                }
                .ForEach(x => context.FlightPlan.Add(x));
                context.SaveChanges();
            }

            var ps = context.FlightPlan.ToList();

            if(!context.AircraftFlightOrFlightPlan.Any())
            {
                new List<AircraftFlightOrFlightPlan>
                {
                    new AircraftFlightOrFlightPlan("Flight", acs[0], admin, admin, fs[0]),
                    new AircraftFlightOrFlightPlan("FlightPlan", acs[0], admin, admin, null, ps[0]),
                    new AircraftFlightOrFlightPlan("FlightPlan", acs[1], admin, admin, null, ps[1]),
                    new AircraftFlightOrFlightPlan("Flight", acs[1], admin, admin, fs[1]),
                    new AircraftFlightOrFlightPlan("FlightPlan", acs[1], admin, admin, null, ps[2]),
                }
                .ForEach(x => context.AircraftFlightOrFlightPlan.Add(x));
                context.SaveChanges();
            }
        }
    }
}
