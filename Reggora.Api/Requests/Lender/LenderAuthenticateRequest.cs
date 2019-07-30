using Reggora.Api.Models.Lender;

namespace Reggora.Api.Requests.Lender
{
    public class LenderAuthenticateRequest : AuthenticateRequest
    {
        public LenderAuthenticateRequest(AuthorizationRequest authInfo) : base("lender", authInfo)
        {
        }
    }
}