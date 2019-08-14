using Newtonsoft.Json;
using Reggora.Api.Entity;
using Reggora.Api.Util;
using RestSharp;
using RestSharp.Serializers.Newtonsoft.Json;

namespace Reggora.Api.Requests.Lender.Loans
{
    public class EditLoanRequest : ReggoraRequest
    {
        public EditLoanRequest(Loan loan) : base("lender/loan/{loan_id}", Method.PUT)
        {
            JsonSerializer = new NewtonsoftJsonSerializer(new JsonSerializer()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include
            });

            AddParameter("loan_id", loan.Id, ParameterType.UrlSegment);

            var request = new Request();
            Utils.DictionaryToJsonFields(request, loan.GetDirtyFieldsForRequest());

            AddJsonBody(request);
        }

        public class Request
        {
            [JsonProperty("number")]
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