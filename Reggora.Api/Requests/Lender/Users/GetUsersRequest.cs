using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using User = Reggora.Api.Requests.Lender.Users.GetUserRequest.Response;

namespace Reggora.Api.Requests.Lender.Users
{
    public class GetUsersRequest : ReggoraRequest
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
            AddParameter("offset", Offset, ParameterType.QueryString);
            AddParameter("limit", Limit, ParameterType.QueryString);
            AddParameter("order", OrderingToString(), ParameterType.QueryString);
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

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }

        public class Response
        {
            [JsonProperty("data")]
            public List<GetUserRequest.Response.User> Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

        }
    }
}