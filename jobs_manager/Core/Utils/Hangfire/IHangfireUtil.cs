using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace jobs_manager.Utils {
    /// <summary>
    /// Util for Hangfire.
    /// </summary>
    public interface IHangfireUtil {
        /// <summary>
        /// Add or update recurring job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="methodCall"></param>
        /// <param name="cronExpression"></param>
        void AddOrUpdateRecurringJob(string jobId, Expression<Func<Task>> methodCall, string cronExpression);

        /// <summary>
        /// Add fire-and-forget job.
        /// </summary>
        /// <param name="methodCall"></param>
        /// <returns></returns>
        string AddFireAndForgetJob(Expression<Func<Task>> methodCall);
    }
}