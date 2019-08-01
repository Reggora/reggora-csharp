namespace Reggora.Api.Requests.Vendor
{
    public class VendorAuthenticateRequest : AuthenticateRequest
    {
        public VendorAuthenticateRequest(string username, string password) : base("vendor", username, password)
        {
        }
    }
}