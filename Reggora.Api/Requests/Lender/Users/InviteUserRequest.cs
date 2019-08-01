using Newtonsoft.Json;
using Reggora.Api.Requests.Lender.Models;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Users
{
    public class InviteUserRequest : RestRequest
    {
        public InviteUserRequest(User user) : base("lender/users", Method.POST)
        {
            AddJsonBody(new Request
            {
                Email = user.Email,
                Role = user.Role,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            });
        }

        public class Request
        {
            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("firstname")]
            public string FirstName { get; set; }

            [JsonProperty("lastname")]
            public string LastName { get; set; }

            [JsonProperty("phone_number")]
            public string PhoneNumber { get; set; }
        }
    }
}