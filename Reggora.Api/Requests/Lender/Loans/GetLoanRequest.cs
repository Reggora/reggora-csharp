using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class GetLoanRequest : ReggoraRequest
    {
        public GetLoanRequest(string loanId) : base("/lender/loan/{loan_id}", Method.GET)
        {
            AddParameter("loan_id", loanId, ParameterType.UrlSegment);
        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }

        public class Response
        {
            [JsonProperty("data")]
            public NestedLoan Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class NestedLoan
            {
                [JsonProperty("loan")]
                public Loan Loan { get; set; }
            }

            public class Loan
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("loan_number")]
                public string LoanNumber { get; set; }

                [JsonProperty("loan_officer")]
                public Officer LoanOfficer { get; set; }

                [JsonProperty("appraisal_type")]
                public string AppraisalType { get; set; }

                [JsonProperty("due_date")]
                public string DueDate { get; set; }

                [JsonProperty("created")]
                public string Created { get; set; }

                [JsonProperty("updated")]
                public string Updated { get; set; }

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

                public class Officer
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("email")]
                    public string Email { get; set; }

                    [JsonProperty("phone_number")]
                    public string PhoneNumber { get; set; }

                    [JsonProperty("firstname")]
                    public string FirstName { get; set; }

                    [JsonProperty("lastname")]
                    public string LastName { get; set; }
                }
            }
        }
    }
}