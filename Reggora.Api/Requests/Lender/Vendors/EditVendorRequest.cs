using Newtonsoft.Json;
using Reggora.Api.Entity;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Vendors
{
    public class EditVendorRequest : ReggoraRequest
    {
        public EditVendorRequest(Vendr vendor) : base("lender/vendor/{vendor_id}", Method.PUT)
        {
            AddParameter("vendor_id", vendor.Id, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                FirmName = vendor.FirmName,
                FirstName = vendor.FirstName,
                LastName = vendor.LastName,
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