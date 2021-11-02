using Newtonsoft.Json;

namespace EmmaSharper
{
    public class SubscriptionSettings
    {
        [JsonProperty("show_on_default_preference_form")]
        public bool ShowOnDefaultPreferenceForm { get; set; }
    }
}
