using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
