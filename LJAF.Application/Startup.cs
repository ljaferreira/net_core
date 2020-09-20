using System;
using System.IO;
using System.Reflection.Metadata;
using LJAF.Infra.CrossCutting.Context;
using LJAF.Infra.CrossCutting.Repositories;
using LJAF.Infra.CrossCutting.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LJAF
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
            services.AddControllers();

            ServicesIoc.Add(services);
            RepositoriesIoc.Add(services);

            ContextIoc.Add(services, Configuration.GetConnectionString("DefaultConnection"));

            var documentationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LJAF.Application.xml");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LJAF", Version = "1.00" });
                if (File.Exists(documentationPath)) c.IncludeXmlComments(documentationPath);
            });
        }

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

            app.UseSwagger(options => { options.RouteTemplate = "{documentName}/swagger.json"; });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "LJAF");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
