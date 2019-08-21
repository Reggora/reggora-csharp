using Newtonsoft.Json;
using Reggora.Api.Entity;
using RestSharp;

namespace Reggora.Api.Requests.Lender.App
{
    public class CustomerAppLinkRequest : ReggoraRequest
    {
        public CustomerAppLinkRequest(string orderId, string consumerId, PaymentApp.LinkType paymentType) : base("lender/{order_id}/{consumer_id}/{link_type}", Method.GET)
        {

            AddParameter("order_id", orderId, ParameterType.UrlSegment);
            AddParameter("consumer_id", consumerId, ParameterType.UrlSegment);
            AddParameter("link_type", PaymentApp.LinkTypeToString(paymentType), ParameterType.UrlSegment);
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
    }
}
