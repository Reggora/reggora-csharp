using Newtonsoft.Json;
using RestSharp;


namespace Reggora.Api.Requests.Lender.Evaults
{
    public class DeleteDocumentRequest : ReggoraRequest
    {
        public DeleteDocumentRequest(string evaultId, string documentId) : base("lender/evault", Method.DELETE)
        {
            AddJsonBody(new Request
            {
                EvaultId = evaultId,
                DocumentId = documentId
            });
        }

        public class Request
        {
            [JsonProperty("id")]
            public string EvaultId { get; set; }

            [JsonProperty("document_id")]
            public string DocumentId { get; set; }
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
