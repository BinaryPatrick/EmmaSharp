using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class CreateSearch
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("criteria")]
        [JsonConverter(typeof(RawStringJsonConverter))]
        public string Criteria { get; set; }
    }
}
