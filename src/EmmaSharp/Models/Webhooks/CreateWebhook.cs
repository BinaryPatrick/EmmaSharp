using Newtonsoft.Json;

namespace EmmaSharp
{
    /// <summary>
    /// Properties associated with creating webhooks
    /// </summary>
    public class CreateWebhook : WebhookBase
    {
        /// <summary>
        /// The public_key to use for authentication. Note: this can also be spelled “user_id” but this is deprecated.
        /// </summary>
        [JsonProperty("public_key", NullValueHandling = NullValueHandling.Ignore)]
        public string PublicKey { get; set; }
    }
}
