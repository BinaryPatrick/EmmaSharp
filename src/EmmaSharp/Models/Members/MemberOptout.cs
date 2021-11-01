using System;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    public class MemberOptout
    {
        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("mailing_id")]
        public long? MailingId { get; set; }
    }
}
