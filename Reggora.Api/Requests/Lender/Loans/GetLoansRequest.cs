using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Requests.Lender.Models;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class GetLoansRequest : RestRequest
    {
        public enum Ordering
        {
            Created
        }

        public uint Offset = 0;
        public uint Limit = 0;
        public Ordering Order = Ordering.Created;
        public string LoanOfficer = null;

        public GetLoansRequest() : base("lender/loans", Method.GET)
        {
            AddParameter("offset", Offset, ParameterType.RequestBody);
            AddParameter("limit", Limit, ParameterType.RequestBody);
            AddParameter("order", OrderingToString(), ParameterType.RequestBody);

            if (LoanOfficer != null)
            {
                AddParameter("loan_officer", LoanOfficer, ParameterType.RequestBody);
            }
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

        public class Response
        {
            [JsonProperty("data")]
            public List<Loan> Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }
    }
}