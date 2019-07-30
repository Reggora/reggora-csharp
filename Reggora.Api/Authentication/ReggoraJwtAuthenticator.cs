using RestSharp;
using RestSharp.Authenticators;

namespace Reggora.Api.Authentication
{
    public class ReggoraJwtAuthenticator : IAuthenticator
    {
        private readonly string _authToken;
        private readonly string _integrationToken;

        public ReggoraJwtAuthenticator(string integrationToken, string authToken)
        {
            _integrationToken = integrationToken;
            _authToken = authToken;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddParameter("Authorization", $"Bearer {_authToken}", ParameterType.HttpHeader);
            request.AddParameter("integration", _integrationToken, ParameterType.HttpHeader);
        }
    }
}