using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Vendors
{
    public class GetVendorsByZoneRequest : RestRequest
    {
        public enum Ordering
        {
            Created
        }

        public uint Offset = 0;
        public uint Limit = 0;
        public Ordering Order = Ordering.Created;

        public GetVendorsByZoneRequest(List<string> zones) : base("lender/vendor/by_zone", Method.GET)
        {
            AddParameter("offset", Offset, ParameterType.RequestBody);
            AddParameter("limit", Limit, ParameterType.RequestBody);
            AddParameter("order", OrderingToString(), ParameterType.RequestBody);

            AddJsonBody(new Request
            {
                Zones = zones
            });
        }

        private string OrderingToString()
        {
            switch (Order)
            {
                case Ordering.Created:
                    return "-created";
            }

            return "";
        }

        public class Request
        {
            [JsonProperty("zones")]
            public List<string> Zones { get; set; }
        }

        public class Response
        {
            [JsonProperty("data")]
            public Nested Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class Nested
            {
                [JsonProperty("vendors")]
                public List<GetVendorRequest.Response.Vendor> Vendors { get; set; }
            }
        }
    }
}