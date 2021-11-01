using System;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    public class MailingInfo : MailingDetails
    {
        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
