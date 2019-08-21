using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class GetSubmissionsRequest : ReggoraRequest
    {
        public GetSubmissionsRequest(string orderId) : base("lender/order-submissions/{order_id}", Method.GET)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);
        }
        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }

        public class Response
        {
            [JsonProperty("data")]
            public NestedSubmission Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class NestedSubmission
            {
                [JsonProperty("submissions")]
                public List<Submission> Submissions { get; set; }
            }
            
            public class Submission
            {
                [JsonProperty("version")]
                public string Version { get; set; }

                [JsonProperty("pdf_report")]
                public string PdfReport { get; set; }

                [JsonProperty("xml_report")]
                public string XmlReport { get; set; }

                [JsonProperty("invoice")]
                public string Invoice { get; set; }
            }
        }
    }
}