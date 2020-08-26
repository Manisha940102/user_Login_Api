using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using user_Login.DataProvider;
using User_Login.DataProvider;

namespace user_Login
{
    public class Startup
    {
        public static string cs { get; private set; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration,IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                    //builder.WithOrigins();
                });
            });
            services.AddSingleton(Configuration);
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<ILoginDataProvider, LoginDataProvider>();
            services.AddTransient<ITakeDataProvider, TakeDataProvider>();
            services.AddTransient<IAddDataProvider, AddDataProvider>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            /*  app.UseCors(builder =>
               {
                   builder.WithOrigins("http://localhost:55077");
                   builder.AllowAnyMethod();
                   builder.AllowAnyHeader();
               });*/

            app.UseCors(MyAllowSpecificOrigins);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
