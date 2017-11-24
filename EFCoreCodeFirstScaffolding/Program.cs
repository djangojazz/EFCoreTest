using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreCodeFirstScaffolding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             * NuGet scripts to run:
             * - Install-Package Microsoft.EntityFrameworkCore.SqlServer
             * - Install-Package Microsoft.EntityFrameworkCore.Tools
             * - This will generate models:
             * Scaffold-DbContext "Server=.;Database=EFCore;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
             */
            //BuildWebHost(args).Run();

            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<EFCoreContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
