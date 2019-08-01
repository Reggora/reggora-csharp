using Newtonsoft.Json;
using Reggora.Api.Authentication;
using Reggora.Api.Requests.Common;
using Reggora.Api.Requests.Lender;
using Reggora.Api.Requests.Lender.Models;
using Reggora.Api.Storage.Lender;
using RestSharp.Serializers.Newtonsoft.Json;
using RestRequest = RestSharp.RestRequest;

namespace Reggora.Api
{
    public class Lender : ApiClient<Lender>
    {
        public readonly LoanStorage Loans;

        public Lender(string integrationToken) : base(integrationToken)
        {
            Loans = new LoanStorage(this);
        }

        public override Lender Authenticate(string email, string password)
        {
            var response = Execute<AuthenticateRequest.Response>(new LenderAuthenticateRequest(new AuthorizationRequest
                {Username = email, Password = password}));

            Client.Authenticator = new ReggoraJwtAuthenticator(_integrationToken, response.Token);

            return this;
        }

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