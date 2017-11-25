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

            List<Users> users = new List<Users>
            {
                new Users("Admin"),
                new Users("Brett")
            };

            if (!context.Users.Any())
            {
                users.ForEach(u => context.Users.Add(u));
                context.SaveChanges();
            }

            var admin = context.Users.Single(x => x.UserId == 1);
            var aircrafts = new List<Aircraft>
            {
                new Aircraft("TestAircraft", admin, admin),
                new Aircraft("TestAircraft2", admin, admin)
            };

            if (!context.Aircraft.Any())
            {
                aircrafts.ForEach(a => context.Aircraft.Add(a));
                context.SaveChanges();
            }
            
        }
    }
}
