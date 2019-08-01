using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Requests.Lender.Loans;
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
            public Order Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

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
                public string Allocation { get; set; }
                
                [JsonProperty("requested_vendors")]
                public List<Vendor> Vendors { get; set; }
                
                [JsonProperty("inspection_complete")]
                public bool InspectionComplete { get; set; }
                
                [JsonProperty("products")]
                public List<Product> Products { get; set; }
                
                [JsonProperty("loan_file")]
                public GetLoanRequest.Response.Loan LoanFile { get; set; }


                public class Vendor
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("firm_name")]
                    public string Name { get; set; }

                    [JsonProperty("accepting_jobs")]
                    public bool AcceptingJobs { get; set; }

                    [JsonProperty("company")]
                    public string Company { get; set; }
                }

                public class Product
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("product_name")]
                    public string Name { get; set; }

                    [JsonProperty("amount")]
                    public string Amount { get; set; }
                }
            }
        }
    }
}