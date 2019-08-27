using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class GetSubmissionRequest : ReggoraRequest
    {
        public GetSubmissionRequest(string orderId, uint version, string reportType) : base(
            "lender/order-submission/{order_id}/{version}/{report_type}", Method.GET)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);
            AddParameter("version", version, ParameterType.UrlSegment);
            AddParameter("report_type", reportType, ParameterType.UrlSegment);
        }
        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }
        public byte[] Download(IRestClient client)
        {
            return client.DownloadData(this, true);
        }
        public class Response
        {
            [JsonProperty("error")]
            public string Error { get; set; }
        }
    }
}