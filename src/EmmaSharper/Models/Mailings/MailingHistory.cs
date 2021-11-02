using System;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class MailingHistory
    {
        [JsonProperty("mailing_type")]
        public MailingType MailingType { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("clicked")]
        public DateTime? Clicked { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("opened")]
        public DateTime? Opened { get; set; }

        [JsonProperty("mailing_id")]
        public long? MailingId { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("delivery_ts")]
        public DateTime? DelieveryTimestamp { get; set; }

        [JsonProperty("delivery_type")]
        public DeliveryTypeShort DelieveryType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("forwarded")]
        public DateTime? Forwarded { get; set; }

        [JsonProperty("parent_mailing_id")]
        public long? ParentMailingId { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("shared")]
        public DateTime? Shared { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("account_id")]
        public long? AccountId { get; set; }
    }
}
