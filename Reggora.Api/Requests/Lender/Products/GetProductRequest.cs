using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Requests.Lender.Products;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Products
{
    public class GetProductRequest : ReggoraRequest
    {
        public GetProductRequest(string productId) : base("lender/product/{product_id}", Method.GET)
        {
            AddParameter("product_id", productId, ParameterType.UrlSegment);
        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }

        public class Response
        {
            [JsonProperty("data")]
            public NestedProduct Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class NestedProduct
            {
                [JsonProperty("loan")]
                public Product Product { get; set; }
            }

            public class Product
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("product_name")]
                public string ProductName { get; set; }

                [JsonProperty("amount")]
                public float Amount { get; set; }

                [JsonProperty("inspection_type")]
                public string InspectionType { get; set; }

                [JsonProperty("requested_forms")]
                public string RequestedForms { get; set; }

            }
        }
    }
}