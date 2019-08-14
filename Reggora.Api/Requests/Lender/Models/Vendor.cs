namespace Reggora.Api.Requests.Lender.Models
{
    public class Vendor
    {
        public string Id;
        public string FirmName;
        public string Email;
        public string Phone;
        public bool AcceptingJobs;
        public LenderCoverage[] LenderCoverage = { };
    }

    public class LenderCoverage
    {
        public int Country;
        public int State;
        public int Zip;
    }
}