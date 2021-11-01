using System;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    public class Field : BaseField
    {
        [JsonProperty("shortcut_name")]
        public string ShortcutName { get; set; }

        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("field_id")]
        public long? FieldId { get; set; }

        [JsonProperty("short_display_name")]
        public string ShortDisplayName { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("options")]
        public string[] Options { get; set; }
    }
}
