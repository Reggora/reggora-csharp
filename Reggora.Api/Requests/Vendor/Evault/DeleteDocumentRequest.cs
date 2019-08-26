using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Vendor.Evault
{
    class DeleteDocumentRequest : ReggoraRequest
    {
        public DeleteDocumentRequest(string evaultId, string documentId) : base("vendor/evault/{evault_id}/{document_id}", Method.DELETE)
        {
            AddParameter("evault_id", evaultId, ParameterType.UrlSegment);
            AddParameter("document_id", documentId, ParameterType.UrlSegment);
        }
    }
}
