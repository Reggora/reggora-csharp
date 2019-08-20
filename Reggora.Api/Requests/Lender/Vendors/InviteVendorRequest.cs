using Newtonsoft.Json;
using RestSharp;
using Reggora.Api.Entity;

namespace Reggora.Api.Requests.Lender.Vendors
{
    public class InviteVendorRequest : ReggoraRequest
    {
        public InviteVendorRequest(Vendr vendor) : base("lender/vendors", Method.POST)
        {
            AddJsonBody(new Request
            {
                FirmName = vendor.FirmName,
                FirstName = vendor.FirstName,
                LastName = vendor.LastName,
                Email = vendor.Email,
                PhoneNumber = vendor.PhoneNumber
            });
        }

        public class Request
        {
            [JsonProperty("firm_name")]
            public string FirmName { get; set; }

            [JsonProperty("firstname")]
            public string FirstName { get; set; }

            [JsonProperty("lastname")]
            public string LastName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("phone")]
            public string PhoneNumber { get; set; }
        }

        public class Response
        {
            [JsonProperty("data")]
            public string Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }
    }
}