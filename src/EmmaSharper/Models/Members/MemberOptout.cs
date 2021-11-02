using System;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
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
