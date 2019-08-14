using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Vendors
{
    public class InviteVendorRequest : RestRequest
    {
        public InviteVendorRequest(Models.Vendor vendor) : base("lender/vendor", Method.POST)
        {
            AddJsonBody(new Request
            {
                FirmName = vendor.FirmName,
                FirstName = "",
                LastName = "",
                Email = vendor.Email,
                Phone = vendor.Phone
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
            public string Phone { get; set; }
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