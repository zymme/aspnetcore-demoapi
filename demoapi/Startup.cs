using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Swashbuckle.AspNetCore.Swagger;

using NLog.Extensions.Logging;
using demoapi.Services;

using Microsoft.Extensions.Options;

using Newtonsoft.Json.Serialization;

namespace demoapi
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
            services.AddMvc()
                    .AddMvcOptions(o => o.OutputFormatters.Add(
                       new XmlDataContractSerializerOutputFormatter()));


            // we want to register our service (lightweight service - localmailservice)
            // so we can inject it elsewhere and use it

#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info{ Title = "Cities API", Version="v1", Description="Sample Cities API"});

            });
           



            //        .AddJsonOptions(o =>
            //{
            //    if(o.SerializerSettings.ContractResolver != null) 
            //    {
            //        var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;

            //        // way to force default serialization to use the way the names are specified on the objects instead 
            //        // of the json default which is lowercase first in property names (camelCase)
            //        // this is also an example of how to add in the pipeline request a way to get at configuration of the API.
            //        castedResolver.NamingStrategy = null;
            //    }
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            loggerFactory.AddNLog();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseMvc();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample Cities API");
				c.ShowRequestHeaders();
			});
        }
    }
}
