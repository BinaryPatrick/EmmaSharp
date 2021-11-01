using System;
using System.Collections.Generic;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    public class ResponseSharesBase
    {
        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("share_clicks")]
        public int? ShareClicks { get; set; }
    }
    public class ResponseShares : ResponseSharesBase
    {
        [JsonProperty("fields")]
        public Dictionary<string, object> Fields { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty("member_id")]
        public long? MemberId { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("member_since")]
        public DateTime? MemberSince { get; set; }

        [JsonProperty("email_domain")]
        public string EmailDomain { get; set; }

        [JsonProperty("email_user")]
        public string EmailUser { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("member_status_id")]
        public MemberStatusShort MemberStatusId { get; set; }
    }

    public class ResponseSharesOverview : ResponseSharesBase
    {
        [JsonProperty("share_count")]
        public int? ShareCount { get; set; }
    }
}
