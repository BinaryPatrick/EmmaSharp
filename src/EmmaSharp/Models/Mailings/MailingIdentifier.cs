using Newtonsoft.Json;

namespace EmmaSharp
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
