using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Reggora.Api.Entity;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Users
{
    public class CreateUserRequest : ReggoraRequest
    {
        public CreateUserRequest(User user) : base("lender/users", Method.POST)
        {
            AddJsonBody(new Request
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Branch = user.Branch,
                Role = user.Role,
                Nmls = user.NmlsId
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
        }
    }
}
