using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EFCoreCodeFirstScaffolding.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstScaffolding
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Much of this is based on: https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db
            services.AddMvc();

            //I can set this up on Startup for injection to be reused universally by all controllers with a statically set connectionstring
            services.AddDbContext<EFCoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EFCore")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
