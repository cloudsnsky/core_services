using System.Reflection;
using System.IO;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

// Reference Swagger for API documentation using swagger built-in.
using Swashbuckle.AspNetCore.Swagger;


// Reference Hangfire
using Hangfire;
using Hangfire.PostgreSql;

// Reference namespaces.
using jobs_manager.Services;
using jobs_manager.Utils;

namespace dot_net_core.Configurations {
    /// <summary>
    /// Configuration Services. It's separated from Startup -> ConfigureServices
    /// </summary>
    public static class ServicesConfiguration {
        /// <summary>
        /// Run configuration.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void Config(IServiceCollection services, IConfiguration configuration) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHangfire(options => 
                options.UsePostgreSqlStorage(configuration.GetConnectionString("Hangfire")));

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Info {
                    Title = "Jobs Manager Api", 
                    Version = "v1"
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            services.AddScoped<IJobsService, JobsService>();

            services.AddScoped<IHttpUtil, HttpUtil>();

            services.AddTransient<IHangfireUtil, HangfireUtil>();

            services.AddHttpClient();
        }
    }
}