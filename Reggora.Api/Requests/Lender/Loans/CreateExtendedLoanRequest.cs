using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class CreateExtendedLoanRequest : ReggoraRequest
    {
        public CreateExtendedLoanRequest(Dictionary<string, object> loanParams) : base("lender/extended_loan", RestSharp.Method.POST)
        {
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
