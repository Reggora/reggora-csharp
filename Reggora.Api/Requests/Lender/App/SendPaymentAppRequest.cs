using Newtonsoft.Json;
using Reggora.Api.Entity;
using Reggora.Api.Util;
using RestSharp;

namespace Reggora.Api.Requests.Lender.App
{
    public class SendPaymentAppRequest : ReggoraRequest
    {
        public SendPaymentAppRequest(PaymentApp app) : base("lender/consumer/payment", Method.POST)
        {

            AddJsonBody(new Request
            {
                ConsumerEmail = app.ConsumerEmail,
                OrderId = app.OrderId,
                UserType = PaymentApp.UserTypeToString(app.UsrType),
                PaymentType = PaymentApp.PaymentTypeToString(app.PaymenType),
                Amount = app.Amount,
                FirstName = app.FirstName,
                LastName = app.LastName,
                Paid = app.Paid

            });

        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }

        public class Response
        {
            [JsonProperty("data")]
            public string Data { get; set; }

            [JsonProperty("error")]
            public string Error { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }
        public class Request
        {
            [JsonProperty("consumer_email")]
            public string ConsumerEmail { get; set; }

            [JsonProperty("order_id")]
            public string OrderId { get; set; }

            [JsonProperty("user_type")]
            public string UserType { get; set; }

            [JsonProperty("payment_type")]
            public string PaymentType { get; set; }

            [JsonProperty("amount")]
            public float Amount { get; set; }

            [JsonProperty("firstname")]
            public string FirstName { get; set; }

            [JsonProperty("lastname")]
            public string LastName { get; set; }

            [JsonProperty("paid")]
            public bool Paid { get; set; }

        }
}
}
