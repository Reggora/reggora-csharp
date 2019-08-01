using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Requests.Lender.Models;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Products
{
    public class CreateProductRequest : RestRequest
    {
        public CreateProductRequest(Product product) : base("lender/product/create", Method.POST)
        {
            AddJsonBody(new Request
            {
                Name = product.ProductName,
                Amount = product.Amount.ToString("N2"),
                Inspection = Product.InspectionToString(product.InspectionType),
                RequestedForms = product.RequestForms
            });
        }

        public class Request
        {
            [JsonProperty("product_name")]
            public string Name { get; set; }

            [JsonProperty("amount")]
            public string Amount { get; set; }

            [JsonProperty("inspection_type")]
            public string Inspection { get; set; }

            [JsonProperty("requested_forms")]
            public List<string> RequestedForms { get; set; }
        }

        public class Response
        {
            [JsonProperty( "data")]
            public string Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }
    }
}