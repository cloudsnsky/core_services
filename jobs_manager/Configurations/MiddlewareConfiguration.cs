using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Hangfire;

using jobs_manager.Configurations;

namespace dot_net_core.Configurations {
    /// <summary>
    /// Configure Middleware. It's separated from Startup -> Configure
    /// </summary>
    public static class MiddlewareConfiguration {
        /// <summary>
        /// Run configuration.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public static void Config(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
            }

            // app.UseHttpsRedirection(); // Enforce to use https

            app.UseHangfireServer();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions() {
                Authorization = new [] { new HangfireAuthorizationFilter() }
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Jobs Manager Api");
                });

            app.UseMvc();
        }
    }
}