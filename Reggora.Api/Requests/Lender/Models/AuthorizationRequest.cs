using Newtonsoft.Json;

namespace Reggora.Api.Requests.Lender.Models
{
    public class AuthorizationRequest
    {
        [JsonProperty("username")]
        public string Username;
        [JsonProperty("password")]
        public string Password;
    }
}