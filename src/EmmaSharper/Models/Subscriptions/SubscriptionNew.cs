using Newtonsoft.Json;

namespace EmmaSharper
{

    public class SubscriptionNew
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
