using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Requests.Lender.Models;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class GetOrderRequest : ReggoraRequest
    {
        public GetOrderRequest(string orderId) : base("lender/order/{order_id}", Method.GET)
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
            public NestedOrder Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class NestedOrder
            {
                [JsonProperty("order")]
                public Order Order { get; set; }
            }

            public class Order
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonProperty("priority")]
                public string Priority { get; set; }

                [JsonProperty("due_date")]
                public string DueDate { get; set; }

                [JsonProperty("inspected_date")]
                public string InspectedDate { get; set; }

                [JsonProperty("accepted_vendor")]
                public Vendor AcceptedVendor { get; set; }

                [JsonProperty("created")]
                public string Created { get; set; }

                [JsonProperty("allocation_mode")]
                public string AllocationMode { get; set; }

                [JsonProperty("requested_vendors")]
                public List<Vendor> Vendors { get; set; }

                [JsonProperty("inspection_complete")]
                public bool InspectionComplete { get; set; }

                [JsonProperty("products")]
                public List<Product> Products { get; set; }

                [JsonProperty("loan_file")]
                public Loan LoanFile { get; set; }

                [JsonProperty("consumers")]
                public List<Consumer> Consumers { get; set; }

                public class Loan
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("loan_number")]
                    public string LoanNumber { get; set; }

                    [JsonProperty("subject_property_address")]
                    public string SubjectPropertyAddress { get; set; }

                    [JsonProperty("subject_property_city")]
                    public string SubjectPropertyCity { get; set; }

                    [JsonProperty("subject_property_state")]
                    public string SubjectPropertyState { get; set; }

                    [JsonProperty("subject_property_zip")]
                    public string SubjectPropertyZip { get; set; }

                }

                public class Vendor
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("firm_name")]
                    public string FirmName { get; set; }

                    [JsonProperty("accepting_jobs")]
                    public bool AcceptingJobs { get; set; }

                    [JsonProperty("email")]
                    public string Email { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonProperty("phone")]
                    public string Phone { get; set; }
                }

                public class Product
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("product_name")]
                    public string ProductName { get; set; }

                    [JsonProperty("amount")]
                    public string Amount { get; set; }
                }
            }
        }
    }
}