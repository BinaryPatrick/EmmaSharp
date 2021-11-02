using System;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
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
