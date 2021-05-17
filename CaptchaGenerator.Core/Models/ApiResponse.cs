using Newtonsoft.Json;

namespace CaptchaGenerator.Core.Models
{
    public class ApiResponse
    {
        public bool success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string error { get; set; }
    }
}
