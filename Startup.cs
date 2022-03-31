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
using Cowrk_Space_Mangment_System.Hubs;
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

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReserveClassRepository, ReserveClassRepository>();
            services.AddScoped<IRawProductRepository, RawProductRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAssignDeal_Repository, AssignDealRepository>();
            services.AddScoped<IAssignPackageRepository, AssignPackageRepository>();
            services.AddScoped<IChairRepository, ChairRepository>();
            services.AddScoped<IChairReserveRepository, ChairReserveRepository>();
            services.AddScoped<IDealsRepository, DealsRepository>();
            services.AddScoped<IDrinkRepository, DrinkRepository>();
            services.AddScoped<IIncommingRepository, IncommingRepository>();
            services.AddScoped<ILogingRepository, LogingRepository>();
            services.AddScoped<IOutgoingRepository, OutgoingRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IProductMovementsRepository, ProductMovementRepository>();
            services.AddScoped<IRawProductMovmentRepository, RawProductMovmentsRepository>();
            services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IClientCart,ClientCartRepository>();
            services.AddScoped<ICartProductsRepository, CartProductsRepository>();
            services.AddSignalR();
            //services.AddIdentity<ApplicationUser, IdentityRole>();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Context>();
        }

        //option => {
        //    option.Password.RequireUppercase = false;
        //    option.Password.RequiredLength = 4;
        //    option.Password.RequireDigit = false;
        //}


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
               endpoints.MapHub<CatringNotificationHub>("CatringNotification");

               endpoints.MapControllerRoute( name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
