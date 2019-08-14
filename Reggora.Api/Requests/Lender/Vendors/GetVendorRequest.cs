using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Vendors
{
    public class GetVendorRequest : RestRequest
    {
        public GetVendorRequest(string vendorId) : base("lender/vendors/{vendor_id}", Method.GET)
        {
            AddParameter("vendor_id", vendorId, ParameterType.UrlSegment);
        }

        public class Response
        {
            [JsonProperty("data")]
            public Nested Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class Nested
            {
                [JsonProperty("vendor")]
                public Vendor Vendor { get; set; }
            }

            public class Vendor
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("firm_name")]
                public string FirmName { get; set; }

                [JsonProperty("email")]
                public string Email { get; set; }

                [JsonProperty("accepting_jobs")]
                public bool AcceptingJobs { get; set; }

                [JsonProperty("lender_coverage")]
                public List<Coverage> LenderCoverage { get; set; }

                public class Coverage
                {
                    [JsonProperty("county")]
                    public string Country { get; set; }

                    [JsonProperty("state")]
                    public string State { get; set; }

                    [JsonProperty("zip")]
                    public string Zip { get; set; }
                }
            }
        }
    }
}