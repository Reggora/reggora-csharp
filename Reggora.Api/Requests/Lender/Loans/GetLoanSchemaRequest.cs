using System;
using System.Collections.Generic;
using System.Text;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class GetLoanSchemaRequest: ReggoraRequest
    {
        public GetLoanSchemaRequest() : base("lender/extended_loan", RestSharp.Method.GET) 
        { 
            
        }
    }
}
