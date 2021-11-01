using Newtonsoft.Json;

namespace EmmaSharp
{

    public class SubscriptionNew
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
