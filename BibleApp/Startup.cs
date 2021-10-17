using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BibleApp
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
            services.AddAutofac();
            services.AddControllersWithViews();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register individual components
            builder.RegisterType<BibleDomain.Managers.BibleBookManager>()
                .As<BibleComonInterface.IBibleBookManager>();
            builder.RegisterType<BibleData.DataRetrieval.BibleJsonLoader>()
                .As<BibleComonInterface.IBibleLoader>().WithParameter(new TypedParameter(typeof(string), Configuration.GetSection("BibleJSONDataPath").Value));
            builder.RegisterType<BibleData.DataRetrieval.BibleUserDataSQLLiteRepo>()
                .As<BibleComonInterface.IBibleUserDataRepo>().WithParameter(new TypedParameter(typeof(string), Configuration.GetSection("DBConnectionString").Value));

            builder.RegisterType<BibleDomain.CoreEntities.Book>()
                .As<BibleComonInterface.IBook>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
