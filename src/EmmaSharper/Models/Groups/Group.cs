using System;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class Group
    {
        [JsonProperty("active_count")]
        public int? ActiveCount { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("error_count")]
        public int? ErrorCount { get; set; }

        [JsonProperty("optout_count")]
        public int? OptoutCount { get; set; }

        [JsonProperty("group_type")]
        public GroupType GroupType { get; set; }

        [JsonProperty("member_group_id")]
        public long? MemberGroupId { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("purged_at")]
        public DateTime? PurgedAt { get; set; }

        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }
    }
}
