using System.Collections.Generic;
using jobs_manager.Models;
using jobs_manager.Services;
using Microsoft.AspNetCore.Mvc;

namespace jobs_manager.Controllers {
    /// <summary>
    /// Jobs controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase {
        private IJobsService _jobsService;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="jobsService"></param>
        public JobsController(IJobsService jobsService) {
            _jobsService = jobsService;
        }

        /// <summary>
        /// Get all jobs. Dummy for now.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get a job by id. Dummy for now.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) {
            return "value";
        }

        /// <summary>
        /// Create a new job.
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Job job) {
            _jobsService.Create(job);
            return Ok();
        }

        /// <summary>
        /// Update a job. Dummy for now.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        /// <summary>
        /// Delete a job. Dummy for now.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
