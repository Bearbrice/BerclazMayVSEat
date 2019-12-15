using BLL;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication
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

            //service added to manage session
            services.AddSession();

            //Scoped additions
            services.AddScoped<IRestaurantManager, RestaurantManager>();
            services.AddScoped<IRestaurantDB, RestaurantDB>();

            services.AddScoped<ICityManager, CityManager>();
            services.AddScoped<ICityDB, CityDB>();

            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<ILoginDB, LoginDB>();

            services.AddScoped<IDishManager, DishManager>();
            services.AddScoped<IDishDB, DishDB>();

            services.AddScoped<IOrdersManager, OrdersManager>();
            services.AddScoped<IOrdersDB, OrdersDB>();

            services.AddScoped<IOrderDishManager, OrderDishManager>();
            services.AddScoped<IOrderDishDB, OrderDishDB>();

            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<ICustomerDB, CustomerDB>();

            services.AddScoped<IStaffManager, StaffManager>();
            services.AddScoped<IStaffDB, StaffDB>();

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //added to manage session
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
