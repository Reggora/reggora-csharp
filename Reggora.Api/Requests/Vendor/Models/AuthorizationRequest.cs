using Newtonsoft.Json;

namespace Reggora.Api.Requests.Vendor.Models
{
    public class AuthorizationRequest
    {
        [JsonProperty("email")]
        public string Email;

        [JsonProperty("password")]
        public string Password;
    }
}