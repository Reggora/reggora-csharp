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
                var result = new GetOrderRequest(id).Execute(Api.Client);
                if (result.Status == 200)
                {
                    returned = new Order();
                    returned.UpdateFromRequest(Utils.DictionaryOfJsonFields(result.Data.Order));
                    Known.Add(returned.Id, returned);
                }
            }

            return returned;
        }
    }
}