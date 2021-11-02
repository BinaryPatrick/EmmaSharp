using System;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class MailingBase
    {
        [JsonProperty("mailing_type")]
        public MailingType MailingType { get; set; }

        [JsonProperty("mailing_id")]
        public long? MailingId { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("send_started")]
        public DateTime? SendStarted { get; set; }

        [JsonProperty("signup_form_id")]
        public long? SignupFormId { get; set; }

        [JsonProperty("recipient_count")]
        public int? RecipientCount { get; set; }

        [JsonProperty("parent_mailing_id")]
        public long? ParentMailingId { get; set; }

        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("mailing_status")]
        public MailingStatus MailingStatus { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("send_finished")]
        public DateTime? SendFinished { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("send_at")]
        public DateTime? SendAt { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("archived_ts")]
        public DateTime? ArchivedTimestamp { get; set; }
    }
}
