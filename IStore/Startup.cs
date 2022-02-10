﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;
using SportsStore2.Models;

namespace SportsStore2
{       
        public class Startup
        {

            public Startup(IConfiguration configuration) =>
                Configuration = configuration;

            public IConfiguration Configuration { get; }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        Configuration["Data:SportStoreProducts:ConnectionString"]));
                services.AddDbContext<AppIndentityDbContext>(options => options.UseSqlServer(Configuration["Data:SportStoreIdentity:ConnectionString"]));
                services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIndentityDbContext>().AddDefaultTokenProviders();
                services.AddTransient<IProductRepository, EFProductRepository>();
                services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                services.AddTransient<IOrderRepository, EFOrderRepository>();
                services.AddMvc();
                services.AddMemoryCache();
                services.AddSession();
            }

            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseSession();
                app.UseAuthentication();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: null,
                        template: "{category}/Page{productPage:int}",
                        defaults: new { controller = "Product", action = "List" }
                    );

                    routes.MapRoute(
                        name: null,
                        template: "Page{productPage:int}",
                        defaults: new { controller = "Product", action = "List", productPage = 1 }
                    );

                    routes.MapRoute(
                        name: null,
                        template: "{category}",
                        defaults: new { controller = "Product", action = "List", productPage = 1 }
                    );

                    routes.MapRoute(
                        name: null,
                        template: "",
                        defaults: new { controller = "Product", action = "List", productPage = 1 });

                    routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
                });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
             }
        }
    
}
