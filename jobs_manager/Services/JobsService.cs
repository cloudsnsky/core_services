using jobs_manager.Models;
using jobs_manager.Utils;

namespace jobs_manager.Services {
    /// <summary>
    /// Jobs Service.
    /// </summary>
    public class JobsService : IJobsService {
        private readonly IHangfireUtil _hangfireUtil;
        private readonly IHttpUtil _httpUtil;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="hangfireUtil"></param>
        /// <param name="httpUtil"></param>
        public JobsService(IHangfireUtil hangfireUtil, IHttpUtil httpUtil) {
            _hangfireUtil = hangfireUtil;
            _httpUtil = httpUtil;
        }

        /// <summary>
        /// Create a job.
        /// </summary>
        /// <param name="job"></param>
        public void Create(Job job) {
            switch (job.Type) {
                case JobType.Recurring: 
                    _hangfireUtil.AddOrUpdateRecurringJob(
                        job.Name, 
                        () => _httpUtil.PostAsync(job.Destination, job.Body), 
                        job.TimeToRun);
                    break;
                default:
                    _hangfireUtil.AddFireAndForgetJob(
                        () => _httpUtil.PostAsync(job.Destination, job.Body));
                    break;
            }
        }
    }
}