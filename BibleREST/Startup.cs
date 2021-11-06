using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleREST
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
            services.AddControllers();
            services.AddAutofac();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
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

    }
}
