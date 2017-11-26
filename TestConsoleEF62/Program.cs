using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleEF62
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFCoreEntities())
            {
                //Will not run right as EF with complex procedures using dynamic sql never realizes how to get their data unless you manually
                //hijack the process and explain how it gets it's data.
                var procresult = context.pGetFlightOrFlightPlan("Flight", null, null);

                //Will work fine as a view for whatever reason hooks up just fine.
                context.vAircraftToFlightsAndFlightPlans.ToList().ForEach(x => Console.WriteLine($"{x.AircraftName} {x.FlightAlias} {x.FlightPlanName} {x.CreatedBy}"));
            }

            Console.ReadLine();
        }
    }
}
