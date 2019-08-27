using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Reggora.Api.Requests.Vendor.Conversation
{
    public class SendMessageRequest : ReggoraRequest
    {
        public SendMessageRequest(string conversationId, string message) : base("vendor/conversation/{conversation_id}", Method.PUT)
        {
            AddParameter("conversation_id", conversationId, ParameterType.UrlSegment);
        }
    }
}