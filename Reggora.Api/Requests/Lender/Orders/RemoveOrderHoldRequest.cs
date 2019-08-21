using System;
using Reggora.Api.Entity;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    class RemoveOrderHoldRequest : ReggoraRequest
    {
        public RemoveOrderHoldRequest(string orderId) : base("lender/order/{order_id}/unhold", Method.PUT)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);
        }
    }
}
