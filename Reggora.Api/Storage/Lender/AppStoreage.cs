using Reggora.Api.Entity;
using Reggora.Api.Requests.Lender.App;
using System;
using System.Collections.Generic;

namespace Reggora.Api.Storage.Lender
{
    public class AppStorage : Storage<PaymentApp, Api.Lender>
    {
        public AppStorage(Api.Lender api) : base(api)
        {
        }

        public string SendPaymentApp(PaymentApp app)
        {
            string response = null;
            var result = new SendPaymentAppRequest(app).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;

            }
            else
            {
                response = result.Error;
            }

            return response;
        }

        public string SendSchedulingApp(List<string> consumerEmails, string orderId)
        {
            string response = null;
            var result = new SendSchedulingAppRequest(consumerEmails, orderId).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;

            }
            else
            {
                response = result.Error;
            }

            return response;
        }

        public string ConsumerAppLink(string orderId, string consumerId, PaymentApp.LinkType paymentType)
        {
            string response = null;
            var result = new CustomerAppLinkRequest(orderId, consumerId, paymentType).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;

            }
            else
            {
                response = result.Error;
            }
            return response;
        }

        public override PaymentApp Get(string id)
        {
            throw new NotImplementedException();
        }

        public override void Save(PaymentApp entity)
        {
            throw new NotImplementedException();
        }
    }
}
