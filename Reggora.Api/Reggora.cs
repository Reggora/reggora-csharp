namespace Reggora.Api
{
    public class Reggora
    {
        public const string BaseUrl = "https://sandbox.reggora.io/";

        public static Lender Lender(string username, string password, string integrationToken)
        {
            return new Lender(integrationToken).Authenticate(username, password);
        }

        public static Vendor Vendor(string email, string password, string integrationToken)
        {
            return new Vendor(integrationToken).Authenticate(email, password);
        }
    }
}