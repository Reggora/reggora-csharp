using Newtonsoft.Json;
using Reggora.Api.Entity;
using Reggora.Api.Util;
using RestSharp;

namespace Reggora.Api.Requests.Vendor.Order
{
    public class CancelVendorOrderRequest : ReggoraRequest
    {
        public CancelVendorOrderRequest(string orderId, string message) : base("vendor/order/{order_id}", Method.DELETE)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                Message = message
            });
        }

        public class Request
        {
            [JsonProperty("message")]
            public string Message { get; set; }
        }
    }
}