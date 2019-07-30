using Reggora.Api.Requests.Common;
using Reggora.Api.Requests.Vendor.Models;

namespace Reggora.Api.Requests.Vendor
{
    public class VendorAuthenticateRequest : AuthenticateRequest
    {
        public VendorAuthenticateRequest(AuthorizationRequest authInfo) : base("vendor", authInfo)
        {
        }
    }
}