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

        public GetLoansRequest(uint offset, uint limit, string ordering, string loanOfficer) : base("lender/loans", Method.GET)
        {
            AddParameter("offset", offset, ParameterType.QueryString);
            AddParameter("limit", limit, ParameterType.QueryString);
            AddParameter("order", ordering, ParameterType.QueryString);

            if (LoanOfficer != null)
            {
                AddParameter("loan_officer", loanOfficer, ParameterType.QueryString);
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