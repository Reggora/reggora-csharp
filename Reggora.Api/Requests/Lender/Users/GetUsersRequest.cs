using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using User = Reggora.Api.Requests.Lender.Users.GetUserRequest.Response;

namespace Reggora.Api.Requests.Lender.Users
{
    public class GetUsersRequest : RestRequest
    {
        public enum Ordering
        {
            Created
        }

        public uint Offset = 0;
        public uint Limit = 0;
        public Ordering Order = Ordering.Created;

        public GetUsersRequest() : base("lender/users", Method.GET)
        {
            AddParameter("offset", Offset, ParameterType.RequestBody);
            AddParameter("limit", Limit, ParameterType.RequestBody);
            AddParameter("order", OrderingToString(), ParameterType.RequestBody);
        }

        private string OrderingToString()
        {
            switch (Order)
            {
                case Ordering.Created:
                    return "-created";
            }

            return "";
        }

        public class Response
        {
            [JsonProperty("data")]
            public List<User> Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }
    }
}