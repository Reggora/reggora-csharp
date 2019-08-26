using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Vendor.Order
{
    public class GetVendorOrdersRequest : ReggoraRequest
    {
        public GetVendorOrdersRequest(uint offset, uint limit, string status) : base("vendor/orders", Method.GET)
        {
            AddParameter("offset", offset, ParameterType.QueryString);
            AddParameter("limit", limit, ParameterType.QueryString);
            
            if(status != null || status != "")
            {
                AddParameter("status", status, ParameterType.QueryString);
            }
        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }

        public class Response
        {
            [JsonProperty("data")]
            public NestedData Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class NestedData
            {
                [JsonProperty("count")]
                public uint Count { get; set; }

                [JsonProperty("orders")]
                public List<GetVendorOrderRequest.Response.Order> Orders { get; set; }
            }
        }
    }
}