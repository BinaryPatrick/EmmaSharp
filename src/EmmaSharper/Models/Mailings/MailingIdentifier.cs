using Newtonsoft.Json;

namespace EmmaSharper
{
    /// <summary>
    /// Class including just the Mailing Identifier.
    /// </summary>
    public class MailingIdentifier
    {
        /// <summary>
        /// Mailing Identifier.
        /// </summary>
        [JsonProperty("mailing_id")]
        public long MailingId { get; set; }
    }
}
