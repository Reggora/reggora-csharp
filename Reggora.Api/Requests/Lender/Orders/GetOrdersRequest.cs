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

        public GetOrdersRequest(uint offset, uint limit, string ordering, string loanOfficer, string filters) : base("lender/orders", Method.GET)
        {
            AddParameter("offset", offset, ParameterType.QueryString);
            AddParameter("limit", limit, ParameterType.QueryString);
            AddParameter("order", ordering, ParameterType.QueryString);
            AddParameter("loan_officer", loanOfficer, ParameterType.QueryString);
            AddParameter("filter", filters, ParameterType.QueryString);
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
            public NestedOrders Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class NestedOrders
            {
                [JsonProperty("orders")]
                public List<GetOrderRequest.Response.Order> Orders { get; set; }
            }
        }
    }
}