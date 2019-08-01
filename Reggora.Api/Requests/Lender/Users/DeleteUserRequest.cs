using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Users
{
    public class DeleteUserRequest : RestRequest
    {
        public DeleteUserRequest(string userId) : base("lender/users/{user_id}", Method.DELETE)
        {
            AddParameter("user_id", userId, ParameterType.UrlSegment);
        }

        public class Response
        {
            [JsonProperty("data")]
            public string Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }
    }
}