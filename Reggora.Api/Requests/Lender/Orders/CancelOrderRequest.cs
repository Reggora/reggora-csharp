using Newtonsoft.Json;
using Reggora.Api.Requests.Lender.Models;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class CancelOrderRequest : RestRequest
    {
        public CancelOrderRequest(Order order) : base("lender/order/{order_id}", Method.DELETE)
        {
            AddParameter("order_id", order.Id, ParameterType.UrlSegment);
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