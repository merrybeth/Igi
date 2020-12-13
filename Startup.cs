using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Google.Apis.Util;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Controllers;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;

namespace Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<IAllBooks, BookRepository>();
            services.AddTransient<IBooksCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<BookRepository>();
            services.AddTransient<EmailController>();
            services.AddDbContext<AppDBContent>(options => options.UseMySql(
                Configuration.GetConnectionString("AppDbContextConnection"),
                new MySqlServerVersion(new Version(8, 0, 22))));
            services.AddSingleton<HttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(ShopBasket.GetBasket);
            services.AddControllersWithViews();
            services.AddMemoryCache();



            services.AddSession();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.Cookie.Domain = ".myshopproject.tk";
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/";
                options.SlidingExpiration = true;
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDBContent>()
                .AddDefaultTokenProviders();
            
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration["Project:GoogleClientId"];
                    options.ClientSecret = Configuration["Project:GoogleClientSecret"];
                    options.Events.OnTicketReceived += OnClientAuthenticated;
                    options.CorrelationCookie.SameSite = SameSiteMode.Lax;
                });
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("categoryFilter", "Book/{action}/{category?}",
                    new {Controller = "Book", action = "List"});
            });


            using (var scope = app.ApplicationServices.CreateScope())
            {
                var content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.initial(content);
            }
        }

        private async Task OnClientAuthenticated(TicketReceivedContext arg)
        {
           
                string email = arg.Principal.Claims.Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Select(c => c.Value).SingleOrDefault();

                if (!string.IsNullOrEmpty(email))
                {
                    var userManager = arg.HttpContext.RequestServices.GetService<SignInManager<ApplicationUser>>();
                    AppDBContent appDbContent =arg.HttpContext.RequestServices.GetService<AppDBContent>();
                    if (appDbContent != null)
                    {
                        var user =await appDbContent.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
                        if (user ==null)
                        {
                           
                            var query = HttpUtility.ParseQueryString("");
                            query["text_main"] = "Этот аккаунт еще не был зарегистрирован";
                            query["text"] = "Пожалуйста, пройдите регистрацию";
                            string queryStr = query.ToString(); 
                            arg.ReturnUri = "Error?" + queryStr ;
                            
                            return;             
                        }

                        if (userManager != null) await userManager.SignInAsync(user, true);
                        else
                        {
                            arg.ReturnUri = "/Error";
                            return;
                        }
                    }

                    return;
                }
            return;
        }

    }
}