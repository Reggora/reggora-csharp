using Reggora.Api.Entity.Lender;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class CancelOrderRequest : ReggoraRequest
    {
        public CancelOrderRequest(Order order) : base("lender/order/{order_id}", Method.DELETE)
        {
            AddParameter("order_id", order.Id.Value, ParameterType.UrlSegment);
        }
    }
}