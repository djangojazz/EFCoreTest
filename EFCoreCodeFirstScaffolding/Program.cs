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
             * Getting dotnet ef to work is incredibly hard you need to reach into the project file and manually upgrade as of writing this on
             * 11/25/2017.  This article points to what to do: https://github.com/aspnet/Scaffolding/issues/645.  In essence you get told that you cannot 
             * install the Microsoft.EntityFrameworkCore.Tools.DotNet as it would be a downgrade but really you just need a higher reference in proj file
             * like so: <PropertyGroup><RuntimeFrameworkVersion>2.0.3</RuntimeFrameworkVersion></PropertyGroup>.  Then it appears you need to also let the 
             * system know of DotNet CLI as well.  NONE OF THIS is built in out of the box to enable migrations.  My experience was similar to Joe Healy's on
             * this link: https://stackoverflow.com/questions/37276882/no-executable-found-matching-command-dotnet-ef
	         * <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.1" />
             * 
             * NuGet scripts to run:
             * - Install-Package Microsoft.EntityFrameworkCore
             * - Install-Package Microsoft.EntityFrameworkCore.SqlServer
             * - Install-Package Microsoft.EntityFrameworkCore.Tools.DotNet
             * - Install-Package Microsoft.EntityFrameworkCore.Relational
             * - This will generate models:
             * Scaffold-DbContext "Server=.;Database=EFCore;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ScaffoldModels
             * 
             * "EFCore": "Server=tcp:brettdb.database.windows.net,1433;Initial Catalog=Expenses;Persist Security Info=False;User ID=bmorin@brettdb;Password=NOPE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;MultipleActiveResultSets=True;App=EntityFramework"
             * "EFCore": "Server=.;Database=EFCore;Trusted_Connection=True;"
             * 
             * Controller commands to use with Fiddler
             * GET: http://localhost:65438/api/aircraft
             * POST: use above with 
             *      header: Content-Type: application/json; charset=utf-8
             *      body: {"aircraftName":"BrettTest","createdBy":{"userId":2}}
             * PUT: use above with an id extension that is valid and header and body similar to above POST
             * DELETE: use above with a valid id extension
             */

            var host = BuildWebHost(args);

            //You need to set up the host differently than out of the box to run an initializer pattern.
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
