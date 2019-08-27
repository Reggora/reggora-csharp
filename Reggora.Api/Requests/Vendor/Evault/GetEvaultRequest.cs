using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Vendor.Evault
{
    class GetEvaultRequest : ReggoraRequest
    {
        public GetEvaultRequest(string evaultId) : base("vendor/evault/{evault_id}", Method.GET)
        {
            AddParameter("evault_id", evaultId, ParameterType.UrlSegment);
        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }

        public class Response
        {
            [JsonProperty("data")]
            public NestedData Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class NestedData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("documents")]
                public List<Document> Documents { get; set; }
            }

            public class Document
            {
                [JsonProperty("document_name")]
                public string DocumentName { get; set; }

                [JsonProperty("document_id")]
                public string DocumentId { get; set; }

                [JsonProperty("upload_datetime")]
                public string UploadDatetime { get; set; }
            }
        }
    }
}
