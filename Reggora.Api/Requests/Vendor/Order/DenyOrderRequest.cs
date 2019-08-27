using Newtonsoft.Json;
using RestSharp;


namespace Reggora.Api.Requests.Vendor.Order
{
    public class DenyOrderRequest : ReggoraRequest
    {
        public DenyOrderRequest(string orderId, string denyReason) : base("vendor/order/{order_id}/deny", Method.PUT)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                DenyReason = denyReason
            });
        }

        public class Request
        {
            [JsonProperty("deny_reason")]
            public string DenyReason { get; set; }
        }
    }
}