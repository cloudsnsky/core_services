using System.ComponentModel.DataAnnotations;

namespace jobs_manager.Models {
    /// <summary>
    /// Job model.
    /// </summary>
    public class Job {
        /// <summary>
        /// Name of Hangfire job.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Type of Hangfire job: Fire-and-forget | Delayed | Recurring.
        /// </summary>
        /// <value></value>
        [Required]
        public JobType Type { get; set; }

        /// <summary>
        /// Time to trigger the job.
        /// </summary>
        /// <value></value>
        public string TimeToRun { get; set; }

        /// <summary>
        /// The api url that will be used to call.
        /// </summary>
        /// <value></value>
        [Required]
        public string Destination { get; set; }

        /// <summary>
        /// HTTP header.
        /// </summary>
        /// <value></value>
        public string Header { get; set; }

        /// <summary>
        /// HTTP body.
        /// </summary>
        /// <value></value>
        [Required]
        public object Body { get; set; }
    }

    /// <summary>
    /// Job Type
    /// </summary>
    public enum JobType {
        /// <summary>
        /// Fire and forget.
        /// </summary>
        FireAndForget = 0, 

        /// <summary>
        /// Delayed.
        /// </summary>
        Delayed, 

        /// <summary>
        /// Recurring.
        /// </summary>
        Recurring
    }
}