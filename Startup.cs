using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Cowrk_Space_Mangment_System.Repository;
using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Cowrk_Space_Mangment_System
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
            services.AddControllersWithViews();
            services.AddDbContext<Context>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("Cs"));
            });



            services.AddIdentity<Admin, IdentityRole>(
           )
               .AddEntityFrameworkStores<Context>();

            services.AddSession(sessionoptions => {
                sessionoptions.IdleTimeout = TimeSpan.FromMinutes(10);

            });



            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IReservationRepository,ReservationRepository>();
            services.AddScoped<IReserveClassRepository, ReserveClassRepository>();
            services.AddScoped<IRawProductRepository, RawProductRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
