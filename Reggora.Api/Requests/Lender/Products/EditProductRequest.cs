using Newtonsoft.Json;
using Reggora.Api.Requests.Lender.Models;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Products
{
    public class EditProductRequest : RestRequest
    {
        public EditProductRequest(Product product) : base("lender/product/{product_id}", Method.PUT)
        {
            AddParameter("product_id", product.Id, ParameterType.UrlSegment);
            AddJsonBody(new CreateProductRequest.Request
            {
                Name = product.ProductName,
                Amount = product.Amount.ToString("N2"),
                Inspection = Product.InspectionToString(product.InspectionType),
                RequestedForms = product.RequestForms
            });
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