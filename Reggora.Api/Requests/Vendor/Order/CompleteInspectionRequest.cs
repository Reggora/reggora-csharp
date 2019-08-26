using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Util;
using RestSharp;

namespace Reggora.Api.Requests.Vendor.Order
{
    public class CompleteInspectionRequest : ReggoraRequest
    {
        public CompleteInspectionRequest(string orderId, DateTime? completedAt) : base("vendor/order/{order_id}/complete_inspection", Method.PUT)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                CompletedAt = Utils.DateToString(completedAt)

            });
        }

        public class Request
        {
            [JsonProperty("inspection_completed")]
            public string CompletedAt { get; set; }
        }
    }
}