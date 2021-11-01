using System;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    public class MailingTrigger : MailingDetails
    {
        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("plaintext")]
        public string Plaintext { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }
    }
}
