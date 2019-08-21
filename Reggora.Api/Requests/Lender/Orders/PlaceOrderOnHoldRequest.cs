using Newtonsoft.Json;
using Reggora.Api.Entity;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    class PlaceOrderOnHoldRequest : ReggoraRequest
    {
        public PlaceOrderOnHoldRequest(string orderId, string reason) : base("lender/order/{order_id}/hold", Method.PUT)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                Reason = reason
            });
        }

        public class Request
        {
            [JsonProperty("reason")]
            public string Reason { get; set; }

        }
    }
}
