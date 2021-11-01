using Newtonsoft.Json;

namespace EmmaSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class Webhook : WebhookBase
    {
        /// <summary>
        /// The Id of the webhook
        /// </summary>
        [JsonProperty("webhook_id")]
        public long? WebhookId { get; set; }

        /// <summary>
        /// The ID associated with the webhook account
        /// </summary>
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }
    }
}
