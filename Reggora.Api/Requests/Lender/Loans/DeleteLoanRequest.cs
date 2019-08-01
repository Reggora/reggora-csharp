using RestSharp;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class DeleteLoanRequest : ReggoraRequest
    {
        public DeleteLoanRequest(string loanId) : base("/lender/loan/{loan_id}", Method.DELETE)
        {
            AddParameter("loan_id", loanId, ParameterType.UrlSegment);
        }
    }
}