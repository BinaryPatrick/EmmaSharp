using Newtonsoft.Json;

namespace EmmaSharp
{
    public class SubscriptionSettings
    {
        [JsonProperty("show_on_default_preference_form")]
        public bool ShowOnDefaultPreferenceForm { get; set; }
    }
}
