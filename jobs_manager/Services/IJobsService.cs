using jobs_manager.Models;

namespace jobs_manager.Services {
    /// <summary>
    /// Jobs service.
    /// </summary>
    public interface IJobsService {
        /// <summary>
        /// Create a job.
        /// </summary>
        /// <param name="job"></param>
        void Create(Job job);
    }
}