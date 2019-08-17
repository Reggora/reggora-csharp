using Reggora.Api.Authentication;
using Reggora.Api.Requests.Lender;
using Reggora.Api.Storage.Lender;
namespace Reggora.Api
{
    public class Lender : ApiClient<Lender>
    {
        public readonly LoanStorage Loans;
        public readonly OrderStorage Orders;

        public Lender(string integrationToken) : base(integrationToken)
        {
            Loans = new LoanStorage(this);
            Orders = new OrderStorage(this);
        }

        public override Lender Authenticate(string email, string password)
        {
            var response = new LenderAuthenticateRequest(email, password).Execute(Client);
            Client.Authenticator = new ReggoraJwtAuthenticator(IntegrationToken, response.Token);

            return this;
        }
    }
}