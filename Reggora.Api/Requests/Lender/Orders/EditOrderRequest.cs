using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Entity;
using Reggora.Api.Util;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class EditOrderRequest : ReggoraRequest
    {
        public EditOrderRequest(Order order, bool refresh) : base("lender/order/{order_id}", Method.PUT)
        {
            AddParameter("order_id", order.Id, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                Allocation = Order.AllocationModeToString(order.Allocation),
//                Loan = order.Loan.Entity.Id,
                Priority = Order.PriorityTypeToString(order.Priority),
//                Products = Array.ConvertAll(order.Products, input => input.Id).ToList(),
                DueDate = Utils.DateToString(order.Due),
//                AdditionalFees = 
                Refresh = refresh
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

            [JsonProperty("due_Date")]
            public string DueDate { get; set; }

            [JsonProperty("additional_fees")]
            public List<string> AdditionalFees { get; set; }

            [JsonProperty("refresh")]
            public bool Refresh { get; set; }

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