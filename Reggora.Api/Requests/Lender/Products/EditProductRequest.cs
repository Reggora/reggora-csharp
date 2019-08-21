using Newtonsoft.Json;
using Reggora.Api.Entity;
using RestSharp;
using Reggora.Api.Util;
using RestSharp.Serializers.Newtonsoft.Json;

namespace Reggora.Api.Requests.Lender.Products
{
    public class EditProductRequest : ReggoraRequest
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

    }
}