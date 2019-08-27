using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Vendor.Evault
{
    class GetDocumentRequest : ReggoraRequest
    {
        public GetDocumentRequest(string evaultId, string documentId) : base("vendor/evault/{evault_id}/{document_id}", Method.GET)
        {
            AddParameter("evault_id", evaultId, ParameterType.UrlSegment);
            AddParameter("document_id", documentId, ParameterType.UrlSegment);
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
