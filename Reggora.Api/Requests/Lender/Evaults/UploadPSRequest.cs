using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Evaults
{
    public class UploadPSRequest : ReggoraRequest
    {
        public UploadPSRequest(string orderId, string filePath, string documentName = null) : base("lender/p_and_s", Method.POST)
        {
            AddParameter("id", orderId);
            AddParameter("document_name", documentName);
            AddFile("file", filePath, MimeMapping.MimeUtility.GetMimeMapping(filePath));
        }
        
        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
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
