using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using TestApi.Models;
using TestApi.Repository;

namespace TestApi
{
    // http://www.dotnetcurry.com/aspnet-mvc/1215/building-aspnet-mvc-6-entity-framework-7-app-using-aspnet-5
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters(a => a.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AppDbContext>(
                    options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            
            services.AddSingleton<ITemperatureReadingRepository, TemperatureReadingRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseMvc();
            //routes =>
            //{
            //    routes.MapRoute(
            //        name: "api",
            //        template: "api/{controller}/{action}/{id?}");
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //}
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
