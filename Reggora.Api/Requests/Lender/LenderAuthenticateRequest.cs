using Reggora.Api.Requests.Common;
using Reggora.Api.Requests.Lender.Models;

namespace Reggora.Api.Requests.Lender
{
    public class LenderAuthenticateRequest : AuthenticateRequest
    {
        public LenderAuthenticateRequest(AuthorizationRequest authInfo) : base("lender", authInfo)
        {
        }
    }
}