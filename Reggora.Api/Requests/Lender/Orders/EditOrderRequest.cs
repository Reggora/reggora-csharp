using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Entity;
using Reggora.Api.Util;
using RestSharp;
using RestSharp.Serializers.Newtonsoft.Json;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class EditOrderRequest : ReggoraRequest
    {
        public EditOrderRequest(Order order, bool refresh) : base("lender/order/{order_id}", Method.PUT)
        {
            JsonSerializer = new NewtonsoftJsonSerializer(new JsonSerializer()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include
            });

            AddParameter("order_id", order.Id, ParameterType.UrlSegment);

            var request = new Request {Refresh = refresh};
            Utils.DictionaryToJsonFields(request, order.GetDirtyFieldsForRequest());

            AddJsonBody(request);
        }

        public class Request
        {
            [JsonProperty("allocation_type")]
            public string AllocationType { get; set; }

            [JsonProperty("priority")]
            public string Priority { get; set; }

            [JsonProperty("products")]
            public List<Product> Products { get; set; }

            [JsonProperty("due_date")]
            public string DueDate { get; set; }

            [JsonProperty("additional_fees")]
            public List<AdditionalFee> AdditionalFees { get; set; }

            [JsonProperty("refresh")]
            public bool Refresh { get; set; }

            public class AdditionalFee
            {
                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("amount")]
                public int Amount { get; set; }
            }
        }
    }
}