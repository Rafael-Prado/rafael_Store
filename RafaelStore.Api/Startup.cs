using System;
using System.IO;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RafaelStore.Domain.StoreContext.Handlers;
using RafaelStore.Domain.StoreContext.Repositories;
using RafaelStore.Domain.StoreContext.Services;
using RafaelStore.Infra.Datacontexts;
using RafaelStore.Infra.StoreContext.Repositories;
using RafaelStore.Infra.StoreContext.Services;
using RafaelStore.Shared;
using Swashbuckle.AspNetCore.Swagger;

namespace RafaelStore.Api
{
    public class Startup
    {
        public static  IConfiguration Configuration {get; set;}
        public void ConfigureServices(IServiceCollection services)
        {
            var buider = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = buider.Build();

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<RafaelStoreContext, RafaelStoreContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();



            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Rafael Store", Version = "v1" });
            });

            Settings.ConnectionString = $"{Configuration["ConnectionString"]}";

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
                app.UseMvc();
                app.UseResponseCompression();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/docs/v1/swagger.json", "Rafael Story V1");
                });

                app.UseElmahIo(apiKey: "c7d402dc70e04d9693f9a05db07a8b47", logId: new Guid("53bc1413-9fe4-4346-b6ca-45c4a1ba5477"));
            
        }
    }
}
