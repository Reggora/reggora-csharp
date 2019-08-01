using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Products
{
    public class GetProductRequest : RestRequest
    {
        public GetProductRequest(string productId) : base("lender/product/{product_id}", Method.GET)
        {
            AddParameter("product_id", productId, ParameterType.UrlSegment);
        }

        public class Response
        {
            [JsonProperty("data")]
            public Product Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class Product
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("product_name")]
                public string Name { get; set; }

                [JsonProperty("inspection_type")]
                public string Amount { get; set; }

                [JsonProperty("requested_forms")]
                public string RequestedForms { get; set; }

                [JsonProperty("geographic_pricing")]
                public Dictionary<string, string> Pricing { get; set; }
            }
        }
    }
}