using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Reggora.Api.Authentication;
using Reggora.Api.Requests.Common;
using Reggora.Api.Requests.Lender;
using Reggora.Api.Requests.Lender.Loans;
using Reggora.Api.Requests.Lender.Models;
using RestSharp;
using RestSharp.Serializers.Newtonsoft.Json;
using RestRequest = RestSharp.RestRequest;

namespace Reggora.Api
{
    public class Lender
    {
        private readonly string _integrationToken;
        private readonly IRestClient _client;

        public Lender(string integrationToken)
        {
            _integrationToken = integrationToken;
            _client = new RestClient(Reggora.BaseUrl);
        }

        public Lender Authenticate(string username, string password)
        {
            var response = Execute<AuthenticateRequest.Response>(new LenderAuthenticateRequest(new AuthorizationRequest
                {Username = username, Password = password}));

            _client.Authenticator = new ReggoraJwtAuthenticator(_integrationToken, response.Token);

            return this;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            request.JsonSerializer = new NewtonsoftJsonSerializer(new JsonSerializer{NullValueHandling = NullValueHandling.Ignore});
            
            var response = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw Reggora.RaiseRequestErrorToException(response.StatusCode, response.ErrorException);
            }

            return response.Data;
        }
    }
}