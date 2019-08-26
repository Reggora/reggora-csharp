using Reggora.Api.Entity;
using Reggora.Api.Requests.Vendor.Conversation;
using Reggora.Api.Util;
using System;

namespace Reggora.Api.Storage.Vendor
{
    public class ConversationManagementStorage : Storage<Conversation, Api.Vendor>
    {
        public ConversationManagementStorage(Api.Vendor api) : base(api)
        {
        }

        public override Conversation Get(string id)
        {
            Known.TryGetValue(id, out var returned);

            if (returned == null)
            {
                var result = new GetConversationRequest(id).Execute(Api.Client);
                if (result.Status == 200)
                {
                    returned = new Conversation();
                    returned.UpdateFromRequest(Utils.DictionaryOfJsonFields(result.Data));
                    Known.Add(returned.Id, returned);
                }
            }

            return returned;
        }

        public string SendMessage(string conversationId, string message = "")
        {
            string response = "";
            var result = new SendMessageRequest(conversationId, message).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        public override void Save(Conversation entity)
        {
            throw new NotImplementedException();
        }
    }
}
