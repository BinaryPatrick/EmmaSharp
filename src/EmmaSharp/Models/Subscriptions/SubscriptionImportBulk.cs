using Newtonsoft.Json;

namespace EmmaSharp
{
    public class SubscriptionImportBulk
    {
        [JsonProperty("import_id")]
        public long ImportId { get; set; }
    }
}
