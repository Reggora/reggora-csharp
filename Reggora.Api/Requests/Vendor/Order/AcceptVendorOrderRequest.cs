using RestSharp;

namespace Reggora.Api.Requests.Vendor.Order
{
    public class AcceptVendorOrderRequest : ReggoraRequest
    {
        public AcceptVendorOrderRequest(string orderId) : base("vendor/order/{order_id}/accept", Method.PUT)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);
        }
    }
}