using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Vendors
{
    public class GetVendorRequest : ReggoraRequest
    {
        public GetVendorRequest(string vendorId) : base("lender/vendor/{vendor_id}", Method.GET)
        {
            AddParameter("vendor_id", vendorId, ParameterType.UrlSegment);
        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
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


                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("firstname")]
                public string FirstName { get; set; }

                [JsonProperty("lastname")]
                public string LastName { get; set; }

                [JsonProperty("email")]
                public string Email { get; set; }

                [JsonProperty("phone")]
                public string Phone { get; set; }

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