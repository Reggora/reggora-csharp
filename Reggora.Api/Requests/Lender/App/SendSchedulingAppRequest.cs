using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Reggora.Api.Requests.Lender.App
{
    class SendSchedulingAppRequest : ReggoraRequest
    {
        public SendSchedulingAppRequest(List<string> consumerEmails, string orderId) : base("lender/consumer/scheduling", Method.POST)
        {

            AddJsonBody(new Request
            {
                ConsumerEmails = consumerEmails,
                OrderId = orderId
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
            [JsonProperty("consumer_emails")]
            public List<string> ConsumerEmails { get; set; }

            [JsonProperty("order_id ")]
            public string OrderId { get; set; }
        }
    }
}
