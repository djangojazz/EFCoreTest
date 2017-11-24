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

            // Look for any students.
            if (context.Aircraft.Any()) { return; }

            new List<Aircraft>
            {
                new Aircraft{AircraftName = "TestAircraft"},
                new Aircraft{AircraftName = "TestAircraft2"}
                //new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                //new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                //new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                //new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                //new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                //new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                //new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            }
            .ForEach(a => context.Aircraft.Add(a));

            context.SaveChanges();
        }
    }
}
