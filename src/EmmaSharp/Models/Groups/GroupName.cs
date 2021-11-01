using Newtonsoft.Json;

namespace EmmaSharp
{
    public class GroupName
    {
        [JsonProperty("group_name")]
        public string Name { get; set; }
    }
}
