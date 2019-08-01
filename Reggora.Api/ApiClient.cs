using System.Net;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.Newtonsoft.Json;
using RestRequest = RestSharp.RestRequest;

namespace Reggora.Api
{
    public abstract class ApiClient<T>
    {
        protected readonly string IntegrationToken;
        public readonly IRestClient Client;
        
        public ApiClient(string integrationToken)
        {
            IntegrationToken = integrationToken;
            Client = new RestClient(Reggora.BaseUrl);
            Client.Proxy = new WebProxy("127.0.0.1", 8888);
        }

        public abstract T Authenticate(string email, string password);
        
        public T Execute<T>(RestRequest request) where T : new()
        {
            request.JsonSerializer = new NewtonsoftJsonSerializer(new JsonSerializer{NullValueHandling = NullValueHandling.Ignore});
            
            var response = Client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw Reggora.RaiseRequestErrorToException(response.StatusCode, response.ErrorException);
            }

            return response.Data;
        }
    }
}