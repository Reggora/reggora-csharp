using Reggora.Api.Entity;
using Reggora.Api.Requests.Lender.Orders;
using Reggora.Api.Util;
using System.Collections.Generic;

namespace Reggora.Api.Storage.Lender
{
    public class OrderStorage : Storage<Order, Api.Lender>
    {
        public OrderStorage(Api.Lender api) : base(api)
        {
        }

        public List<Order> All(uint offset = 0, uint limit = 0, string ordering = "-created", string loanOfficer = null, string filters = "")
        {
            var result = new GetOrdersRequest(offset, limit, ordering, loanOfficer, filters).Execute(Api.Client);
            var fetchedOrders = result.Data.Orders;
            List<Order> orders = new List<Order>();

            if (result.Status == 200)
            {
                for (int i = 0; i < fetchedOrders.Count; i++)
                {
                    Order tempOrder = new Order();
                    tempOrder.UpdateFromRequest(Utils.DictionaryOfJsonFields(fetchedOrders[i]));
                    orders.Add(tempOrder);
                }
            }
            return orders;
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

        public string Create(Order order)
        {
            string response = null;
            var result = new CreateOrderRequest(order).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
                order.Clean();

            }

            return response;
        }

        public string Edit(Order order)
        {
            string response = "";
            var result = new EditOrderRequest(order, false).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
                order.Clean();
            }
            return response;
        }

        public string Cancel(string orderId)
        {
            string response = null;
            var result = new CancelOrderRequest(orderId).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        public string OnHold(string orderId, string reason)
        {
            string response = null;
            var result = new PlaceOrderOnHoldRequest(orderId, reason).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        public string RemoveHold(string orderId)
        {
            string response = null;
            var result = new RemoveOrderHoldRequest(orderId).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        public List<Submission> Submissions(string orderId)
        {
            var result = new GetSubmissionsRequest(orderId).Execute(Api.Client);
            var fetchedSubmissions = result.Data.Submissions;
            List<Submission> submissions = new List<Submission>();

            if (result.Status == 200)
            {
                for (int i = 0; i < fetchedSubmissions.Count; i++)
                {
                    Submission tempSubmission = new Submission();
                    tempSubmission.UpdateFromRequest(Utils.DictionaryOfJsonFields(fetchedSubmissions[i]));
                    submissions.Add(tempSubmission);
                }
            }
            return submissions;
        }
    }
}