using System;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    public class Subscription
    {
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("import_status")]
        public string ImportStatus { get; set; }

        [JsonProperty("member_count")]
        public int? MemberCount { get; set; }

        [JsonProperty("modified_at")]
        public string ModifiedAt { get; set; }

        [JsonProperty("optout_count")]
        public int? OptoutCount { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("purged_at")]
        public DateTime? PurgedAt { get; set; }

        [JsonProperty("settings")]
        public SubscriptionSettings Settings { get; set; }

        [JsonProperty("subscription_id")]
        public long? SubscriptionId { get; set; }

        [JsonProperty("subscription_name")]
        public string SubscriptionName { get; set; }

        [JsonProperty("subscription_order")]
        public int? SubscriptionOrder { get; set; }
    }
}
