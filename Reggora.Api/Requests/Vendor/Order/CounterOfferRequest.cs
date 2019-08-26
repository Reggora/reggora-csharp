using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Util;
using RestSharp;

namespace Reggora.Api.Requests.Vendor.Order
{
    public class CounterOfferRequest : ReggoraRequest
    {
        public CounterOfferRequest(string orderId, DateTime? dueDate, float? fee) : base("vendor/order/{order_id}/counter", Method.PUT)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                DueDate = Utils.DateToString(dueDate),
                Fee = fee

            });
        }

        public class Request
        {
            [JsonProperty("due_date")]
            public string DueDate { get; set; }

            [JsonProperty("fee")]
            public float? Fee { get; set; }
        }
    }
}