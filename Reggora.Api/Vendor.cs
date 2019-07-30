using Reggora.Api.Authentication;
using Reggora.Api.Requests.Common.Models;
using Reggora.Api.Requests.Vendor;
using Reggora.Api.Requests.Vendor.Models;
using RestSharp;

namespace Reggora.Api
{
    public class Vendor
    {
        private readonly string _integrationToken;
        private readonly IRestClient _client;

        public Vendor(string integrationToken)
        {
            _integrationToken = integrationToken;
            _client = new RestClient(Reggora.BaseUrl);
        }

        public Vendor Authenticate(string email, string password)
        {
            var response = Execute<AuthorizationResponse>(new VendorAuthenticateRequest(new AuthorizationRequest
                {Email = email, Password = password}));

            _client.Authenticator = new ReggoraJwtAuthenticator(_integrationToken, response.Token);

            return this;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw Reggora.RaiseRequestErrorToException(response.StatusCode, response.ErrorException);
            }

            return response.Data;
        }
    }
}