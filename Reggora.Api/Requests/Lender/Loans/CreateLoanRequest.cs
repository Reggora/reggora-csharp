using Newtonsoft.Json;
using Reggora.Api.Requests.Lender.Models;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class CreateLoanRequest : RestRequest
    {
        public CreateLoanRequest(Loan loan) : base("lender/loan/create", Method.POST)
        {
            AddJsonBody(new Request
            {
                LoanNumber = loan.LoanNumber,
                AppraisalType = loan.AppraisalType,
                DueDate = loan.DueDate,
                RelatedOrder = loan.RelatedOrder,
                SubjectPropertyAddress = loan.SubjectPropertyAddress,
                SubjectPropertyCity = loan.SubjectPropertyCity,
                SubjectPropertyState = loan.SubjectPropertyState,
                SubjectPropertyZip = loan.SubjectPropertyZip,
                CaseNumber = loan.CaseNumber,
                LoanType = loan.LoanType
            });
        }

        public class Request
        {
            [JsonProperty("number")]
            public string LoanNumber { get; set; }
            [JsonProperty("appraisal_type")]
            public string AppraisalType  { get; set; }
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
            public int? SubjectPropertyZip { get; set; }
            [JsonProperty("case_number")]
            public string CaseNumber { get; set; }
            [JsonProperty("type")]
            public string LoanType { get; set; }
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