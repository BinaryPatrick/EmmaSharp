using Newtonsoft.Json;

namespace EmmaSharper
{
    public class Email
    {
        [JsonProperty("email")]
        public string Value { get; set; }
    }
}
