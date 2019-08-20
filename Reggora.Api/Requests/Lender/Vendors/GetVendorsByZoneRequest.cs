using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Vendors
{
    public class GetVendorsByZoneRequest : ReggoraRequest
    {
        public enum Ordering
        {
            Created
        }

        public uint Offset = 0;
        public uint Limit = 0;
        public Ordering Order = Ordering.Created;

        public GetVendorsByZoneRequest(List<string> zones) : base("lender/vendors/by_zone", Method.POST)
        {
            AddParameter("offset", Offset, ParameterType.QueryString);
            AddParameter("limit", Limit, ParameterType.QueryString);
            AddParameter("order", OrderingToString(),  ParameterType.QueryString);

            AddJsonBody(new Request
            {
                Zones = zones
            });
        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
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