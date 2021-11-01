using Newtonsoft.Json;

namespace EmmaSharp
{
    public class WorkflowCount
    {
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("draft")]
        public int Draft { get; set; }

        [JsonProperty("active")]
        public int Active { get; set; }

        [JsonProperty("inactive")]
        public int Inactive { get; set; }
    }
}

