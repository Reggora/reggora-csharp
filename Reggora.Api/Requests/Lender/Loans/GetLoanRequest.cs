using Newtonsoft.Json;
using Reggora.Api.Requests.Lender.Models;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class GetLoanRequest : RestRequest
    {
        public GetLoanRequest(string loanId) : base("/lender/loan/{loan_id}", Method.GET)
        {
            AddParameter("loan_id", loanId, ParameterType.UrlSegment);
        }

        public class Response
        {
            [JsonProperty("data")]
            public Loan Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }
    }
}