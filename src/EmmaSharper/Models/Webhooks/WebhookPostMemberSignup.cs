using Newtonsoft.Json;

namespace EmmaSharper
{
    public class WebhookPostMemberSignup
    {
        [JsonProperty("event_name")]
        public string EventName { get; set; }

        [JsonProperty("resource_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ResourceUrl { get; set; }

        [JsonProperty("data")]
        public WebhookPostDataMemberSignup Data { get; set; }
    }
}
