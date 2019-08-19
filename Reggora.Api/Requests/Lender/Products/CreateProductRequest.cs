using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Entity;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Products
{
    public class CreateProductRequest : ReggoraRequest
    {
        public CreateProductRequest(Product product) : base("lender/product", Method.POST)
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
            public string RequestedForms { get; set; }
        }
    }
}