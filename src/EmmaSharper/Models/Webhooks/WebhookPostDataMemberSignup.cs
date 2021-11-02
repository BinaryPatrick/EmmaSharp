using System;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class WebhookPostDataMemberSignup
    {
        [JsonProperty("signup_form_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SignupFormId { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("member_id")]
        public string MemberId { get; set; }

        [JsonProperty("mailing_id", NullValueHandling = NullValueHandling.Ignore)]
        public long MailingId { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

    }
}
