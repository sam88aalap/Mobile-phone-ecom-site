using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopon.BusinessLayer.Implementation;
using Shopon.DataLayer.Contracts;
using Shopon.DataLayer.Implementation;
using ShopOn.BusinessLayer.Contracts;
using ShopOn.BusinessLayer.Implementation;
using ShopOn.DataLayer.Contracts;
using ShopOnEFLayer.Implementations;
using ShopOnEFLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOn.WebApp
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
            //config ef
            services.AddDbContext<db_shoponContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            //config identity service
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<db_shoponContext>();

            // mapping iproduct repository
            services.AddTransient<IProductRepository,ProductRepositoryEFImpl>();
            //mapping product manager
            services.AddTransient<IProductManager, ProductManager>();

            //Map IOrderManage
            services.AddTransient<IOrderManager, OrderManager>();

            //Map IOrderRepository
            services.AddTransient<IOrderRepository, OrderRepositoryDBImpl>();

            //httpcontextaccessor
            services.AddHttpContextAccessor();

            // config session
            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddControllersWithViews();
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
