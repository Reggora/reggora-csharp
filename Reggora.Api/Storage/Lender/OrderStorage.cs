using Reggora.Api.Entity;
using Reggora.Api.Requests.Lender.Orders;
using Reggora.Api.Util;

namespace Reggora.Api.Storage.Lender
{
    public class OrderStorage : Storage<Order, Api.Lender>
    {
        public OrderStorage(Api.Lender api) : base(api)
        {
        }

        public override Order Get(string id)
        {
            Known.TryGetValue(id, out var returned);

            if (returned == null)
            {
                // TODO: Verify response
                var result = new GetOrderRequest(id).Execute(Api.Client).Data;
                returned = new Order();
                returned.UpdateFromRequest(Utils.DictionaryOfJsonFields(result.Order));
                Known.Add(returned.Id, returned);
            }

            return returned;
        }
    }
}