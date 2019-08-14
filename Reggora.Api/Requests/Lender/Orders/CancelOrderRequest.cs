using Reggora.Api.Entity;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class CancelOrderRequest : ReggoraRequest
    {
        public CancelOrderRequest(Order order) : base("lender/order/{order_id}", Method.DELETE)
        {
            AddParameter("order_id", order.Id, ParameterType.UrlSegment);
        }
    }
}