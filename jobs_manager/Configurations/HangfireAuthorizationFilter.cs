using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace jobs_manager.Configurations {
    /// <summary>
    /// Implement IDashboardAuthorizationFilter to override some features.
    /// </summary>
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter {
        /// <summary>
        /// Override Authorize method to allow all users access hangfire dashboard.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool Authorize([NotNull] DashboardContext context) {
            return true;
        }
    }
}