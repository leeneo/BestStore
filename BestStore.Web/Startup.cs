using BestStore.Data;
using BestStore.Data.Interfaces;
using BestStore.Data.Repositories;
using BestStore.Models;
using BestStore.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace BestStore.Web
{
    public class Startup {

        //Safe storage of app secrets during development in ASP.NET Core
        //string _testSecret = null;

        //ASP.Net Core 1.1
        //public IConfiguration Configuration { get; }

        //ASP.Net Core 2.0
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
 
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            //_testSecret = Configuration["MySecret"];

            // Dependencies Injection
            AddDependencies(services);

            // Add framework services.
            //services.AddDbContext<BestStoreDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<WebappUser, IdentityRole>()
                .AddEntityFrameworkStores<BestStoreDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add framework services.DotNet Core 1.1;
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=BestStoreStDB;Trusted_Connection=True;";
            //services.AddDbContext<BestStoreDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("BestStore.Web")));

            // Add session
            services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(20));

            // Add application services.DotNet Core 2.0;
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {

            //var result = string.IsNullOrEmpty(_testSecret) ? "Null" : "Not Null";
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"Secret is {result}");
            //});

            app.UseSession();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }
            app.UseStaticFiles ();
#pragma warning disable CS0618 // 类型或成员已过时
            app.UseIdentity();
#pragma warning restore CS0618 // 类型或成员已过时

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715
            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Loading sample data.
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory> ().CreateScope ()) {
                var dbContext = serviceScope.ServiceProvider.GetService<BestStoreDbContext> ();
                bool HasCreated = dbContext.Database.EnsureCreated ();
                if (HasCreated) {
                    SampleDataInitializer dbInitializer = new SampleDataInitializer (dbContext);
                    dbInitializer.LoadBasicInformationAsync ().Wait ();
                    dbInitializer.LoadSampleDataAsync ().Wait ();
                }

            }
        }

        //依赖注入类型的注册一般是在程序启动的入口中，如Startup.cs中的ConfigureServices中，该类的主要目的就是注册依赖注入的类型
        public IServiceCollection AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IShipAddressRepository, ShipAddressRepository>();
            services.AddScoped<BestStoreDbContext>();

            //注册单例模式，整个应用程序周期内ITodoRepository接口的示例都是TodoRepository的一个单例实例
            //services.AddSingleton<ITodoRepository, TodoRepository>();
            //services.AddSingleton(typeof(ITodoRepository), typeof(TodoRepository));  // 等价形式

            // 注册作用域型的类型，在特定作用域内ITodoRepository的示例
            services.AddScoped<ITodoRepository, TodoRepository>();
            //services.AddScoped(typeof(ITodoRepository), typeof(TodoRepository));// 等价形式

            //获取该ITodoRepository实例时，每次都要实例化一次TodoRepository类
            //services.AddTransient<ITodoRepository, TodoRepository>();
            //services.AddTransient(typeof(ITodoRepository), typeof(TodoRepository));// 等价形式

            //如果要注入的类没有接口，那你可以直接注入自身类型，比如：
            //services.AddTransient<LoggingHelper>();
            return services;
        }

    }
}