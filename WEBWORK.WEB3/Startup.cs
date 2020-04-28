using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WEBWORK.DATA.Data;
using WEBWORK.DATA.Models;
using WEBWORK.WEB3.Configurations;
using WEBWORK.WEB3.Models;
using WEBWORK.WEB3.Repositories.IRepositories;
using WEBWORK.WEB3.Repositories.Repositories;

namespace WEBWORK.WEB3
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
            services.AddCorsConfiguration();
            services.AddMiddleware();
            services.AddConnectionProvider(Configuration);
            services.AddCostumeMVC();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(
                    "v1", 
                    new Microsoft.OpenApi.Models.OpenApiInfo { Title = "School Manager API", Description = "School Management System Documentation" })  ;
            });

            services.AddScoped<IStudentRepository, StudentRepository>();
          


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 docs");
            });

            //SeedData.SeedDatabase(services.GetRequiredService<ApplicationContext>());

            //IdentitySeedData.SeedDatabase(services).Wait();

        }
    }
}
