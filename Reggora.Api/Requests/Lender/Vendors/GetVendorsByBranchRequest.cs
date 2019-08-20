using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Vendors
{
    public class GetVendorsByBranchRequest : ReggoraRequest
    {
        public enum Ordering
        {
            Created
        }

        public uint Offset = 0;
        public uint Limit = 0;
        public Ordering Order = Ordering.Created;

        public GetVendorsByBranchRequest(string branchId) : base("lender/vendors/branch", Method.GET)
        {
            AddParameter("branch_id", branchId, ParameterType.QueryString);
            AddParameter("offset", Offset, ParameterType.QueryString);
            AddParameter("limit", Limit, ParameterType.QueryString);
            AddParameter("order", OrderingToString(), ParameterType.QueryString);
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
                [JsonProperty("vendors")]
                public List<GetVendorRequest.Response.Vendor> Vendors { get; set; }
            }
        }
    }
}