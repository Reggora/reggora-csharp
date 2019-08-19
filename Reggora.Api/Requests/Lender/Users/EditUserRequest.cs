using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Reggora.Api.Entity;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Users
{
    public class EditUserRequest : ReggoraRequest
    {
        public EditUserRequest(User user) : base("lender/users/{user_id}", Method.PUT)
        {
            AddParameter("user_id", user.Id, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.FirstName,
                PhoneNumber = user.PhoneNumber,
                Branch = user.Branch,
                Role = user.Role,
                Nmls = user.NmlsId,
                MatchedUsers = Array.ConvertAll(user.MatchedUsers, input => input.Id).ToList()
            });
        }

        public class Request
        {
            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("firstname")]
            public string FirstName { get; set; }

            [JsonProperty("lastname")]
            public string LastName { get; set; }

            [JsonProperty("phone_number")]
            public string PhoneNumber { get; set; }

            [JsonProperty("branch_id")]
            public string Branch { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("nmls_id")]
            public string Nmls { get; set; }

            [JsonProperty("matched_users")]
            public List<string> MatchedUsers { get; set; }
        }
    }
}