using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Users
{
    public class GetUserRequest : ReggoraRequest
    {
        public GetUserRequest(string userId) : base("lender/users/{user_id}", Method.GET)
        {
            AddParameter("user_id", userId, ParameterType.UrlSegment);
        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }

        public class Response
        {
            [JsonProperty("data")]
            public User Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class User
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("email")]
                public string Email { get; set; }

                [JsonProperty("phone_number")]
                public string PhoneNumber { get; set; }

                [JsonProperty("firstname")]
                public string FirstName { get; set; }

                [JsonProperty("lastname")]
                public string LastName { get; set; }

                [JsonProperty("nmls_id")]
                public string Nmls { get; set; }

                [JsonProperty("created")]
                public string Created { get; set; }

                [JsonProperty("role")]
                public string Role { get; set; }

                [JsonProperty("matched_users")]
                public List<Matched> MatchedUsers { get; set; }

                public class Matched
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("email")]
                    public string Email { get; set; }

                    [JsonProperty("firstname")]
                    public string FirstName { get; set; }

                    [JsonProperty("lastname")]
                    public string LastName { get; set; }
                }
            }
        }
            
    }
}