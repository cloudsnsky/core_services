using System.Threading.Tasks;

using jobs_manager.Models;

namespace jobs_manager.Utils {
    /// <summary>
    /// Util for Http calling.
    /// </summary>
    public interface IHttpUtil {
        /// <summary>
        /// Call a post request.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        Task PostAsync(string uri, object body);
    }
}