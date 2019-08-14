using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.Newtonsoft.Json;
using RestRequest = RestSharp.RestRequest;

namespace Reggora.Api.Requests
{
    public abstract class ReggoraRequest : RestRequest
    {
        protected ReggoraRequest(string resource, Method method) : base(resource, method)
        {
            RequestFormat = DataFormat.Json;
            JsonSerializer = new NewtonsoftJsonSerializer();
        }

        protected T Execute<T>(IRestClient client) where T : new()
        {
            var response = client.Execute<T>(this);

            if (response.ErrorException != null)
            {
                throw Reggora.RaiseRequestErrorToException(response.StatusCode, response.ErrorException);
            }

            return response.Data;
        }

        public BasicResponse Execute(IRestClient client)
        {
            return Execute<BasicResponse>(client);
        }

        public class BasicResponse
        {
            [JsonProperty("data")]
            public string Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }
    }
}