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
            
            if (!context.Aircraft.Any())
            {
                new List<Aircraft>
                {
                    new Aircraft("TestAircraft", users[0]),
                    new Aircraft("TestAircraft2", users[0])
                }
                .ForEach(
                    a => context.Aircraft.Add(a)
                    );

                context.SaveChanges();
            }
            
        }
    }
}
