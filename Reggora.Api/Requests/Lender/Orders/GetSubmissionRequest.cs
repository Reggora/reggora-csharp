using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class GetSubmissionRequest : ReggoraRequest
    {
        public GetSubmissionRequest(string orderId, int version, string type) : base(
            "lender/order-submission/{order_id}/{version}/{type}", Method.GET)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);
            AddParameter("version", version, ParameterType.UrlSegment);
            AddParameter("type", type, ParameterType.UrlSegment);
        }
    }
}