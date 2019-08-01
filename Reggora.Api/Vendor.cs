using Reggora.Api.Authentication;
using Reggora.Api.Requests.Vendor;

namespace Reggora.Api
{
    public class Vendor : ApiClient<Vendor>
    {
        public Vendor(string integrationToken) : base(integrationToken)
        {
        }
        
        public override Vendor Authenticate(string email, string password)
        {
            var response = new VendorAuthenticateRequest(email, password).Execute(Client);

            Client.Authenticator = new ReggoraJwtAuthenticator(IntegrationToken, response.Token);

            return this;
        }
    }
}