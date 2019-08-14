using RestSharp;

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
        }

        public abstract T Authenticate(string email, string password);
    }
}