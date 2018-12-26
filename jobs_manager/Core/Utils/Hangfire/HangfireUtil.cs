using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hangfire;

namespace jobs_manager.Utils {
    /// <summary>
    /// Util for Hangfire.
    /// </summary>
    public class HangfireUtil : IHangfireUtil {
        /// <summary>
        /// Add or update recurring job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="methodCall"></param>
        /// <param name="cronExpression"></param>
        public void AddOrUpdateRecurringJob(string jobId, Expression<Func<Task>> methodCall, string cronExpression) {
            RecurringJob.AddOrUpdate(jobId, 
                methodCall, 
                cronExpression, 
                TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Add fire-and-forget job.
        /// </summary>
        /// <param name="methodCall"></param>
        /// <returns></returns>
        public string AddFireAndForgetJob(Expression<Func<Task>> methodCall) {
            return BackgroundJob.Enqueue(methodCall);
        }
    }
}