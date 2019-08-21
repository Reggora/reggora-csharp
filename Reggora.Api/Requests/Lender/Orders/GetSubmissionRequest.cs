using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class GetSubmissionRequest : ReggoraRequest
    {
        public GetSubmissionRequest(string orderId, int version, string report_type) : base(
            "lender/order-submission/{order_id}/{version}/{report_type}", Method.GET)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);
            AddParameter("version", version, ParameterType.UrlSegment);
            AddParameter("report_type", report_type, ParameterType.UrlSegment);
        }
    }
}