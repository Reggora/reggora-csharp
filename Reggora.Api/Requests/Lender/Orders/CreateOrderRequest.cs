using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Entity;
using Reggora.Api.Util;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class CreateOrderRequest : ReggoraRequest
    {
        public CreateOrderRequest(Order order) : base("lender/order/create", Method.POST)
        {
            AddParameter("order_id", order.Id, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                Allocation = Order.AllocationModeToString(order.Allocation),
//                Vendors = order.RequestedVendors.ToList(),
//                Loan = order.Loan.Entity.Id.Value,
                Priority = Order.PriorityTypeToString(order.Priority),
//                Products = Array.ConvertAll(order.Products, input => input.Id).ToList(),
                DueDate = Utils.DateToString(order.Due),
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
    }
}