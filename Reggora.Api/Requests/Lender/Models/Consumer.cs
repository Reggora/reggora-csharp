using Newtonsoft.Json;

namespace Reggora.Api.Requests.Lender.Models
{
    public class Consumer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("home_phone")]
        public string HomePhone { get; set; }

        [JsonProperty("work_phone")]
        public string WorkPhone { get; set; }

        [JsonProperty("cell_phone")]
        public string CellPhone { get; set; }

        [JsonProperty("is_primary_contact")]
        public bool IsPrimaryContact { get; set; }
    }
}
