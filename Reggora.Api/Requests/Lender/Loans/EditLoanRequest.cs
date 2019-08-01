using Newtonsoft.Json;
using Reggora.Api.Entity.Lender;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class EditLoanRequest : ReggoraRequest
    {
        public EditLoanRequest(Loan loan) : base("lender/loan/{loan_id}", Method.PUT)
        {
            AddParameter("loan_id", loan.Id.Value, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                LoanNumber = loan.Number.Value.ToString(),
                AppraisalType = loan.Type.Value,
                DueDate = loan.Due.ToDate(),
                SubjectPropertyAddress = loan.Property.Value.Address.Value,
                SubjectPropertyCity = loan.Property.Value.City.Value,
                SubjectPropertyState = loan.Property.Value.State.Value,
                SubjectPropertyZip = loan.Property.Value.Zip.Value,
                CaseNumber = loan.Number.Value.ToString(),
                LoanType = loan.Type.Value
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
            public string SubjectPropertyZip { get; set; }
            [JsonProperty("case_number")]
            public string CaseNumber { get; set; }
            [JsonProperty("type")]
            public string LoanType { get; set; }
        }
    }
}