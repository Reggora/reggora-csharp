using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Vendor.Order
{
    public class GetVendorOrderRequest : ReggoraRequest
    {
        public GetVendorOrderRequest(string orderId) : base("vendor/order/{order_id}", Method.GET)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);
        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }

        public class Response
        {
            [JsonProperty("data")]
            public Order Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class Order
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonProperty("property_street")]
                public string PropertyStreet { get; set; }

                [JsonProperty("property_city")]
                public string PropertyCity { get; set; }

                [JsonProperty("property_state")]
                public string PropertyState { get; set; }

                [JsonProperty("property_zip")]
                public string PropertyZip { get; set; }

                [JsonProperty("priority")]
                public string Priority { get; set; }

                [JsonProperty("request_expiration")]
                public string RequestExpiration { get; set; }

                [JsonProperty("due_date")]
                public string DueDate { get; set; }

                [JsonProperty("lender")]
                public Lendr Lender { get; set; }

                [JsonProperty("loan_file")]
                public Loan LoanFile { get; set; }

                [JsonProperty("consumers")]
                public List<Consumer> Consumers { get; set; }

                [JsonProperty("schedule")]
                public Schdl Schedule { get; set; }

                [JsonProperty("evault")]
                public string Evault { get; set; }

                [JsonProperty("conversation")]
                public string Conversation { get; set; }

                [JsonProperty("products")]
                public List<Product> Products { get; set; }

                [JsonProperty("submissions")]
                public List<Submission> Submissions { get; set; }

                [JsonProperty("revisions")]
                public List<Revision> Revisions { get; set; }


                public class Lendr
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }
                }

                public class Loan
                {
                    [JsonProperty("occupancy_type")]
                    public string OccupancyType { get; set; }

                    [JsonProperty("attachment_type")]
                    public string AttachmentType { get; set; }

                    [JsonProperty("agency_case_number")]
                    public string AgencyCaseNumber { get; set; }

                    [JsonProperty("loan_type")]
                    public string LoanType { get; set; }

                    [JsonProperty("number_of_units")]
                    public string NumberOfUnits { get; set; }

                    [JsonProperty("appraisal_type")]
                    public string AppraisalType { get; set; }

                    [JsonProperty("number")]
                    public string Number { get; set; }

                }

                public class Consumer
                {
                    [JsonProperty("full_name")]
                    public string FullName { get; set; }

                    [JsonProperty("role")]
                    public string Role { get; set; }

                    [JsonProperty("email")]
                    public string Email { get; set; }

                    [JsonProperty("home_phone")]
                    public string HomePhone { get; set; }

                    [JsonProperty("cell_phone")]
                    public string CellPhone { get; set; }

                    [JsonProperty("work_phone")]
                    public string WorkPhone { get; set; }

                }

                public class Schdl
                {
                    [JsonProperty("available_dates")]
                    public List<string> AvailableDates { get; set; }
                }

                public class Product
                {
                    [JsonProperty("description")]
                    public string Description { get; set; }

                    [JsonProperty("forms")]
                    public List<string> Forms { get; set; }

                    [JsonProperty("amount")]
                    public uint Amount { get; set; }

                    [JsonProperty("inspection_type")]
                    public string InspectionType { get; set; }
                }

                public class Submission
                {
                    [JsonProperty("created")]
                    public string Created { get; set; }

                    [JsonProperty("pdf_report")]
                    public string PdfReport { get; set; }

                    [JsonProperty("xml_report")]
                    public string XmlReport { get; set; }

                    [JsonProperty("invoice")]
                    public string Invoice { get; set; }

                    [JsonProperty("additional_files")]
                    public List<string> AdditionalFiles { get; set; }

                    [JsonProperty("version")]
                    public uint Version { get; set; }
                }

                public class Revision
                {
                    [JsonProperty("created")]
                    public string Created { get; set; }

                    [JsonProperty("updated")]
                    public string Updated { get; set; }

                    [JsonProperty("lender_resolved")]
                    public string LenderResolved { get; set; }

                    [JsonProperty("vendor_completed")]
                    public string VendorCompleted { get; set; }

                    [JsonProperty("text")]
                    public string Text { get; set; }

                    [JsonProperty("title")]
                    public string Title { get; set; }
                }

            }
        }
    }
}