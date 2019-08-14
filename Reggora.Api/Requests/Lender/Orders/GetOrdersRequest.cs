using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class GetOrdersRequest : ReggoraRequest
    {
        public enum Ordering
        {
            Created
        }

        public uint Offset = 0;
        public uint Limit = 0;
        public Ordering Order = Ordering.Created;

        public GetOrdersRequest() : base("lender/orders", Method.GET)
        {
            AddParameter("offset", Offset, ParameterType.QueryString);
            AddParameter("limit", Limit, ParameterType.QueryString);
            AddParameter("order", OrderingToString(), ParameterType.QueryString);
        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
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
            public List<GetOrderRequest.Response.Order> Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }
    }
}