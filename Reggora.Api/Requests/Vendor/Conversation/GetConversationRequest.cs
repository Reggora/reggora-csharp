using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Vendor.Conversation
{
    public class GetConversationRequest : ReggoraRequest
    {
        public GetConversationRequest(string conversationId) : base("vendor/conversation/{conversation_id}", Method.GET)
        {
            AddParameter("conversation_id", conversationId, ParameterType.UrlSegment);
        }

        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }

        public class Response
        {
            [JsonProperty("data")]
            public NestedData Data { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            public class NestedData
            {
                [JsonProperty("conversation")]
                public Conversation Conversation { get; set; }

            }

            public class Conversation
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("vendor_users")]
                public List<User> VendorUsers { get; set; }

                [JsonProperty("lender_users")]
                public List<User> LenderUsers { get; set; }

                [JsonProperty("messages")]
                public List<Msg> Messages { get; set; }

                public class User
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }
                }

                public class Msg
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("message")]
                    public string Message { get; set; }

                    [JsonProperty("sender")]
                    public User Sender { get; set; }

                    [JsonProperty("sent_time")]
                    public string SentTime { get; set; }
                }
            }
        }
    }
}