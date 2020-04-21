using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Data;


namespace WEBWORK.WEB3.Configurations
{
    public static class ServiceConfigurations
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration)
        {

          
            services.AddDbContext<ApplicationContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WEBWORK.WEB3")));

            return services;

        }

        public static IServiceCollection AddCostumeMVC(this IServiceCollection services) {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            return services;
        }


        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            });

            services.AddMvcCore().AddJsonFormatters(j =>
            {
                j.ContractResolver = new DefaultContractResolver();
                j.Formatting = Formatting.Indented;
            });

            //services.AddControllersWithViews()
            //    .AddJsonOptions(opts => {
            //        opts.JsonSerializerOptions.IgnoreNullValues = true;
            //    }).AddNewtonsoftJson();


            return services;
        }


        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
       services.AddCors(options =>
       {
           options.AddPolicy("AllowAll", new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder()
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin()
           .AllowCredentials()
           .Build());
       });





    }
}
