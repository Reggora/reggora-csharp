using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class EditExtendedLoanRequest : ReggoraRequest
    {
        public EditExtendedLoanRequest(string loanID, Dictionary<string, object> loanParams) : base("lender/extended_loan/{loan_id}", RestSharp.Method.PUT)
        {
            AddParameter("loan_id", loanID, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                Loan = loanParams
            });
        }

        public class Request
        {
            [JsonProperty("loan")]
            public Dictionary<string, object> Loan { get; set; }
        }
    }
}
