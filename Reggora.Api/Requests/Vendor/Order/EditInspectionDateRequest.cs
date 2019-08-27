using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Util;
using RestSharp;


namespace Reggora.Api.Requests.Vendor.Order
{
    public class EditInspectionDateRequest : ReggoraRequest
    {
        public EditInspectionDateRequest(string orderId, DateTime? inspectionDate) : base("vendor/order/{order_id}/set_inspection", Method.PUT)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);

            AddJsonBody(new Request
            {
                InspectionDate = Utils.DateToString(inspectionDate)
            });
        }

        public class Request
        {
            [JsonProperty("inspection_date")]
            public string InspectionDate { get; set; }
        }
    }
}