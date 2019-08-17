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

        public void Save(Order order, bool refresh)
        {
            var result = new EditOrderRequest(order, refresh).Execute(Api.Client);

            if (result.Status == 200)
            {
                order.Clean();
            }
        }

        public override void Save(Order order)
        {
            Save(order, false);
        }

        public override Order Create(Order order)
        {
            Known.TryGetValue(order.Id, out var returned);
            var result = new CreateOrderRequest(order).Execute(Api.Client);
            if (result.Status == 200)
            {
                returned = Get(result.Data);

            }

            return returned;
        }

        public override Order Edit(Order order)
        {
            Order response = new Order();
            var result = new EditOrderRequest(order, false).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = Get(result.Data);
                order.Clean();
            }
            return response;
        }
    }
}