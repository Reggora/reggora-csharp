using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests
{
    public abstract class AuthenticateRequest : ReggoraRequest
    {
        protected AuthenticateRequest(string type, string username, string password) : base($"{type}/auth", Method.POST)
        {
            AddJsonBody(new Request
            {
                Username = username,
                Password = password
            });
        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }

        public class Request
        {
            [JsonProperty("username")]
            public string Username;

            [JsonProperty("password")]
            public string Password;
        }

        public class Response
        {
            [JsonProperty("token")]
            public string Token { get; set; }
        }
    }
}