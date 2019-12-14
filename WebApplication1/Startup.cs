using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<ICitiesManager, CitiesManager>();
            services.AddScoped<ICitiesDB, CitiesDB>();

            services.AddScoped<IRestaurantsManager, RestaurantsManager>();
            services.AddScoped<IRestaurantsDB, RestaurantsDB>();

            services.AddScoped<IDishesManager, DishesManager>();
            services.AddScoped<IDishesDB, DishesDB>();

            services.AddScoped<ICustomersManager, CustomersManager>();
            services.AddScoped<ICustomersDB, CustomersDB>();

            services.AddScoped<IDeliversManager, DeliversManager>();
            services.AddScoped<IDeliversDB, DeliversDB>();

            services.AddScoped<IOrdersManager, OrdersManager>();
            services.AddScoped<IOrdersDB, OrdersDB>();

            services.AddScoped<ICustomerLoginsManager, CustomerLoginsManager>();
            services.AddScoped<ICustomerLoginsDB, CustomerLoginsDB>();

            services.AddScoped<IDeliverLoginsManager, DeliverLoginsManager>();
            services.AddScoped<IDeliverLoginsDB, DeliverLoginsDB>();
            
            services.AddScoped<IOrderDishesManager, OrderDishesManager>();
            services.AddScoped<IOrderDishesDB, OrderDishesDB>();



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
