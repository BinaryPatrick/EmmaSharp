using Newtonsoft.Json;

namespace EmmaSharp
{
    public class Email
    {
        [JsonProperty("email")]
        public string Value { get; set; }
    }
}
