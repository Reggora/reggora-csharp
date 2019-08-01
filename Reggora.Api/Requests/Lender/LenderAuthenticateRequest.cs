namespace Reggora.Api.Requests.Lender
{
    public class LenderAuthenticateRequest : AuthenticateRequest
    {
        public LenderAuthenticateRequest(string username, string password) : base("lender", username, password)
        {
        }
    }
}