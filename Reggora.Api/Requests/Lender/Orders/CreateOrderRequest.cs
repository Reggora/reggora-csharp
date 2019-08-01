using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Reggora.Api.Requests.Lender.Models;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class CreateOrderRequest : RestRequest
    {
        public CreateOrderRequest(Order order) : base("lender/order/create", Method.POST)
        {
            AddParameter("order_id", order.Id, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                Allocation = Order.AllocationToString(order.AllocationMode),
                Vendors = order.RequestedVendors.ToList(),
                Loan = order.LoanFile.Id,
                Priority = Order.PriorityToString(order.PriorityType),
                Products = Array.ConvertAll(order.Products, input => input.Id).ToList(),
                DueDate = order.DueDate,
//                AdditionalFees = 
            });
        }

        public class Request
        {
            [JsonProperty("allocation_type")]
            public string Allocation { get; set; }

            [JsonProperty("vendors")]
            public List<string> Vendors { get; set; }

            [JsonProperty("loan")]
            public string Loan { get; set; }

            [JsonProperty("priority")]
            public string Priority { get; set; }

            [JsonProperty("products")]
            public List<string> Products { get; set; }

            [JsonProperty("due_Date")]
            public string DueDate { get; set; }

            [JsonProperty("additional_fees")]
            public List<string> AdditionalFees { get; set; }

            public class AdditionalFee
            {
                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("amount")]
                public int Amount { get; set; }
            }
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