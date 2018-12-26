using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

using NLog.Web;

namespace jobs_manager
{
    /// <summary>
    /// The main program class. The very first running code block.
    /// </summary>
    public class Program {
        /// <summary>
        /// The main function will be used.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try {
                logger.Debug("init main");
                CreateWebHostBuilder(args).Build().Run();
            } catch (Exception e) {
                logger.Error(e, "Stopped program because of exception");
                throw;
            } finally {
                NLog.LogManager.Shutdown();
            }
        }

        /// <summary>
        /// Create a web host builder.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();
    }
}
