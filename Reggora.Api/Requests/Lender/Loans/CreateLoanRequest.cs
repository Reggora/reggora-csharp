using Newtonsoft.Json;
using Reggora.Api.Entity;
using Reggora.Api.Util;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class CreateLoanRequest : ReggoraRequest
    {
        public CreateLoanRequest(Loan loan) : base("lender/loan", Method.POST)
        {
            AddJsonBody(new Request
            {
                LoanNumber = loan.Number.ToString(),
                AppraisalType = loan.Type,
                DueDate = Utils.DateToString(loan.Due),
                SubjectPropertyAddress = loan.PropertyAddress,
                SubjectPropertyCity = loan.PropertyCity,
                SubjectPropertyState = loan.PropertyState,
                SubjectPropertyZip = loan.PropertyZip,
                CaseNumber = loan.Number.ToString(),
                LoanType = loan.Type
            });
        }

        public class Request
        {
            [JsonProperty("loan_number")]
            public string LoanNumber { get; set; }

            [JsonProperty("appraisal_type")]
            public string AppraisalType { get; set; }

            [JsonProperty("due_date")]
            public string DueDate { get; set; }

            [JsonProperty("related_order")]
            public string RelatedOrder { get; set; }

            [JsonProperty("subject_property_address")]
            public string SubjectPropertyAddress { get; set; }

            [JsonProperty("subject_property_city")]
            public string SubjectPropertyCity { get; set; }

            [JsonProperty("subject_property_state")]
            public string SubjectPropertyState { get; set; }

            [JsonProperty("subject_property_zip")]
            public string SubjectPropertyZip { get; set; }

            [JsonProperty("case_number")]
            public string CaseNumber { get; set; }

            [JsonProperty("loan_type")]
            public string LoanType { get; set; }
        }
    }
}