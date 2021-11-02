using Newtonsoft.Json;

namespace EmmaSharper
{
    public class SubscriptionImportBulk
    {
        [JsonProperty("import_id")]
        public long ImportId { get; set; }
    }
}
