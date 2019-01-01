using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using automobility_api.Data;
using automobility_api.Features.Auth.Models;
using automobility_api.Features.GoogleMaps.Directions.Services;
using automobility_api.Features.Parking.Repository;
using automobility_api.Features.Parking.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace automobility_api
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
            //add DBContext
            services.AddDbContext<DataContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            //seeds database
            DbContextExtensions.UserManager = services.BuildServiceProvider().GetService<UserManager<AppUser>>();

            services.AddTransient<IParkingLotService, ParkingLotService>();
            services.AddTransient<IParkingLotRepository, ParkingLotRepository>();
            services.AddTransient<IDirectionService, DirectionService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseMvc();
        }

    }
}
