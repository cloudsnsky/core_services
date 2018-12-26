using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using jobs_manager.Models;
using Newtonsoft.Json;

namespace jobs_manager.Utils {
    /// <summary>
    /// Util for Http calling.
    /// </summary>
    public class HttpUtil : IHttpUtil {
        private IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public HttpUtil(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Call a post request.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task PostAsync(string uri, object body) {
            var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            await client.PostAsync(uri, stringContent);
        }
    }
}