using Newtonsoft.Json;

namespace Reggora.Api.Requests.Lender.Models
{
    public class Loan
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("loan_number")]
        public string LoanNumber { get; set; }
//        [JsonProperty("loan_officer")]
//        public string LoanOfficer { get; set; }
        [JsonProperty("appraisal_type")]
        public string AppraisalType  { get; set; }
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
        public int? SubjectPropertyZip { get; set; }
        [JsonProperty("case_number")]
        public string CaseNumber { get; set; }
        [JsonProperty("loan_type")]
        public string LoanType { get; set; }
    }

    public class LoanOfficer
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}