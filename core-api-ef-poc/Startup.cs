﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthLib;
using AuthLib.Models;
using core_api_ef_poc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace core_api_ef_poc
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
            var connection = @"Server=(localdb)\mssqllocaldb;Database=core-api-ef-poc-db;Trusted_Connection=True;ConnectRetryCount=0";
            services
                .AddMvc()
                .AddAuthLib()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<AuthLibDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("core-api-ef-poc")));

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
