using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using ShopBasket = Shop.Data.Models.ShopBasket;

namespace Shop
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IWebHostEnvironment hostEnvironment)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("dbsettings.json").Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<IAllBooks, BookRepository>();
            services.AddTransient<IBooksCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddDbContext<AppDBContent>(options => options.UseMySql(
                "server=localhost;user=root;password=ei7veeChu4bo!;database=shop;",
                new MySqlServerVersion(new Version(8, 0, 22))));
            services.AddSingleton<HttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(ShopBasket.GetBasket);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSession();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("categoryFilter", "Book/{action}/{category?}",
                    new {Controller = "Book", action = "List"});
            });
            app.UseAuthentication();    
            app.UseAuthorization();     
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.initial(content);
            }

            ;
        }
    }
}