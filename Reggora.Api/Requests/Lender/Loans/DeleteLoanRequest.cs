using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class DeleteLoanRequest : RestRequest
    {
        public DeleteLoanRequest(string loanId) : base("/lender/loan/{loan_id}", Method.DELETE)
        {
            AddParameter("loan_id", loanId, ParameterType.UrlSegment);
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