using System;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class MailingInfo : MailingDetails
    {
        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
