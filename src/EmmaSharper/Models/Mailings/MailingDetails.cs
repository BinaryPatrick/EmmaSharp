using System;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class MailingDetails : MailingBase
    {

        [JsonProperty("cancel_by_user_id")]
        public long? CancelByUserId { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("cancel_ts")]
        public DateTime? CancelTimestamp { get; set; }

        [JsonProperty("month")]
        public int? Month { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("failure_ts")]
        public DateTime? FailureTimestamp { get; set; }

        [JsonProperty("reply_to")]
        public string ReplyTo { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("start_or_finished")]
        public DateTime? StartedOrFinished { get; set; }

        [JsonProperty("disabled")]
        public bool Disabled { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("created_ts")]
        public DateTime? CreatedTimestamp { get; set; }

        [JsonProperty("plaintext_only")]
        public bool PlaintextOnly { get; set; }

        [JsonProperty("failure_message")]
        public string FailureMessage { get; set; }

        [JsonProperty("datacenter")]
        public string Datacenter { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("purged_at")]
        public DateTime? PurgedAt { get; set; }
    }
}
