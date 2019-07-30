using System;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Common
{
    public abstract class AuthenticateRequest : RestRequest
    {
        protected AuthenticateRequest(string type, Object authInfo) : base($"{type}/auth", Method.POST)
        {
            AddJsonBody(authInfo);
        }

        public class Response
        {
            [JsonProperty("token")]
            public string Token { get; set; }
        }
    }
}