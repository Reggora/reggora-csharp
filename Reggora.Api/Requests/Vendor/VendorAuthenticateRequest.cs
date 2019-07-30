using Reggora.Api.Models.Vendor;

namespace Reggora.Api.Requests.Vendor
{
    public class VendorAuthenticateRequest : AuthenticateRequest
    {
        public VendorAuthenticateRequest(AuthorizationRequest authInfo) : base("vendor", authInfo)
        {
        }
    }
}