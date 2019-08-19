using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Products
{
    public class GetProductsRequest : ReggoraRequest
    {
        public enum Ordering
        {
            Created
        }

        public uint Offset = 0;
        public uint Limit = 0;
        public Ordering Order = Ordering.Created;

        public GetProductsRequest() : base("lender/products", Method.GET)
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
            public NestedProducts Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class NestedProducts
            {
                [JsonProperty("products")]
                public List<GetProductRequest.Response.Product> Products { get; set; }
            }
        }
    }
}