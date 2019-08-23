using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class GetLoansRequest : ReggoraRequest
    {
        public enum Ordering
        {
            Created
        }

        public uint Offset = 0;
        public uint Limit = 0;
        public Ordering Order = Ordering.Created;
        public string LoanOfficer = null;

        public GetLoansRequest(uint Offset, uint Limit, string Ordering, string LoanOfficer) : base("lender/loans", Method.GET)
        {
            AddParameter("offset", Offset, ParameterType.QueryString);
            AddParameter("limit", Limit, ParameterType.QueryString);
            AddParameter("order", Ordering, ParameterType.QueryString);

            if (LoanOfficer != null)
            {
                AddParameter("loan_officer", LoanOfficer, ParameterType.QueryString);
            }
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

        public class Response
        {
            [JsonProperty("data")]
            //public List<GetLoanRequest.Response.Loan> Data { get; set; }
            public NestedLoans Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class NestedLoans
            {
                [JsonProperty("loans")]
                public List<GetLoanRequest.Response.Loan> Loans { get; set; }
            }
        }
    }
}