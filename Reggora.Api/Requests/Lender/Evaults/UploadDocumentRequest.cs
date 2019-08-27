using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Evaults
{
    public class UploadDocumentRequest : ReggoraRequest
    {
        public UploadDocumentRequest(string evaultId, string filePath) : base("lender/evault", Method.POST)
        {

            AddParameter("id", evaultId);

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
