using Reggora.Api.Authentication;
using Reggora.Api.Requests.Vendor;
using Reggora.Api.Storage.Vendor;

namespace Reggora.Api
{
    public class Vendor : ApiClient<Vendor>
    {
        public readonly OrderManagementStorage VendorOrders;
        public readonly ConversationManagementStorage Conversations;
        public readonly EvaultManagementStorage Evaults;

        public Vendor(string integrationToken) : base(integrationToken)
        {
            VendorOrders = new OrderManagementStorage(this);
            Conversations = new ConversationManagementStorage(this);
            Evaults = new EvaultManagementStorage(this);
        }

        public override Vendor Authenticate(string email, string password)
        {
            var response = new VendorAuthenticateRequest(email, password).Execute(Client);

            Client.Authenticator = new ReggoraJwtAuthenticator(IntegrationToken, response.Token);

            return this;
        }
    }
}