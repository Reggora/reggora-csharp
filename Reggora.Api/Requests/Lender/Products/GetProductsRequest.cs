using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Product = Reggora.Api.Requests.Lender.Products.GetProductRequest.Response.Product;

namespace Reggora.Api.Requests.Lender.Products
{
    public class GetProductsRequest : RestRequest
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
            public List<Product> Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }
    }
}