using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Reggora.Api.Requests.Lender.Evaults
{
    public class GetEvaultRequest : ReggoraRequest
    {
        public GetEvaultRequest(string evaultId) : base("lender/evault/{evault_id}", Method.GET)
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
            public Nested Data { get; set; }

            [JsonProperty("error")]
            public string Error { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class Nested
            {
                [JsonProperty("evault")]
                public Evlt Evault { get; set; }
            }

            public class Evlt
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("documents")]
                public List<Document> Documents { get; set; }

                public class Document
                {
                    [JsonProperty("document_id")]
                    public string DocumentId { get; set; }

                    [JsonProperty("document_name")]
                    public string DocumentName { get; set; }

                    [JsonProperty("upload_datetime")]
                    public string UploadedAt { get; set; }
                }
            }
        }
    }
}
