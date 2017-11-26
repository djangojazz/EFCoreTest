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
            
            if (!context.Users.Any())
            {
                new List<Users>
                {
                    new Users("Admin"),
                    new Users("Brett")
                }
                .ForEach(u => context.Users.Add(u));
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
                .ForEach(a => context.Aircraft.Add(a));
                context.SaveChanges();
            }

            if (!context.Flight.Any())
            {
                new List<Flight>
                {
                    new Flight("737", admin, admin),
                    new Flight("747", admin, admin)
                }
                .ForEach(a => context.Flight.Add(a));
                context.SaveChanges();
            }

            //insert into Flight Values('Flight1', getdate(), 1, getdate(), 1),('Flight2', getdate(), 2, getdate(), 2)
            //insert into FlightPlan Values(1, 'FlightPlan1-A', getdate(), 1, getdate(), 1),(1, 'FlightPlan1-B', getdate(), 1, getdate(), 1),(2, 'FlightPlan2', getdate(), 2, getdate(), 2)
            //insert into Aircraft_FlightOrFlightPlan Values('Flight', 1, 1, null, getdate(), 1, getdate(), 1),('FlightPlan', 1, null, 1, getdate(), 1, getdate(), 1)
            //,('FlightPlan', 2, null, 2, getdate(), 1, getdate(), 1),('Flight', 2, 2, null, getdate(), 1, getdate(), 1),('FlightPlan', 2, null, 3, getdate(), 1, getdate(), 1)
        }
    }
}
