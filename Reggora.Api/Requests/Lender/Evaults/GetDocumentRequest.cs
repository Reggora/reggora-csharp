using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Evaults
{
    public class GetDocumentRequest : ReggoraRequest
    {
        public GetDocumentRequest(string evaultId, string documentId) : base("lender/evault/{evault_id}/{document_id}", Method.GET)
        {
            AddParameter("evault_id", evaultId, ParameterType.UrlSegment);
            AddParameter("document_id", documentId, ParameterType.UrlSegment);
        }
    }
}
