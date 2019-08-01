using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Products
{
    public class DeleteProductRequest : RestRequest
    {
        public DeleteProductRequest(string productId) : base("lender/product/{product_id}", Method.DELETE)
        {
            AddParameter("product_id", productId, ParameterType.UrlSegment);
        }

        public class Response
        {
            [JsonProperty("data")]
            public string Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }
    }
}