using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Entity;
using Reggora.Api.Util;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class CreateOrderRequest : ReggoraRequest
    {
        public CreateOrderRequest(Order order) : base("lender/order", Method.POST)
        {

            AddJsonBody(new Request
            {
                Allocation = Order.AllocationModeToString(order.Allocation),
                Loan = order.Loan,
                Products = order.ProductIds,
                Priority = Order.PriorityTypeToString(order.Priority),
                DueDate = Utils.DateToString(order.Due),
                AdditionalFees = order.AdditionalFees ?? new List<Request.AdditionalFee>()
            });

        }

        public class Request
        {
            [JsonProperty("allocation_type")]
            public string Allocation { get; set; }

            [JsonProperty("loan")]
            public string Loan { get; set; }

            [JsonProperty("priority")]
            public string Priority { get; set; }

            [JsonProperty("products")]
            public List<string> Products { get; set; }

            [JsonProperty("due_date")]
            public string DueDate { get; set; }

            [JsonProperty("additional_fees")]
            public List<AdditionalFee> AdditionalFees { get; set; }

            public class AdditionalFee
            {
                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("amount")]
                public int Amount { get; set; }
            }
        }
    }
}