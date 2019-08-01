using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Vendors
{
    public class DeleteVendorRequest : RestRequest
    {
        public DeleteVendorRequest(string vendorId) : base("lender/vendor/{vendor_id}", Method.DELETE)
        {
            AddParameter("vendor_id", vendorId, ParameterType.UrlSegment);
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