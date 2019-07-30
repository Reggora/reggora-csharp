using System;
using System.Linq;
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
            // only add the Authorization parameter if it hasn't been added by a previous Execute
            if (!request.Parameters.Any(p => p.Type.Equals(ParameterType.HttpHeader) &&
                                             p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
            {
                request.AddParameter("Authorization", $"Bearer {_authToken}", ParameterType.HttpHeader);
                request.AddParameter("integration", _integrationToken);
            }
        }
    }
}