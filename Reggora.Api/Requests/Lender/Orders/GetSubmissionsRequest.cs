using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class GetSubmissionsRequest : ReggoraRequest
    {
        public GetSubmissionsRequest(string orderId) : base("lender/get-submissions/{order_id}", Method.GET)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);
        }

        public class Response
        {
            [JsonProperty("version")]
            public string Version { get; set; }
            
            [JsonProperty("pdf_report")]
            public string Pdf { get; set; }
            
            [JsonProperty("xml_report")]
            public string Xml { get; set; }
            
            [JsonProperty("invoice")]
            public string Invoice { get; set; }
        }
    }
}