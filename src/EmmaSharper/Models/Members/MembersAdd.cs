using Newtonsoft.Json;

namespace EmmaSharper
{
    public class MembersAdd
    {
        [JsonProperty("import_id")]
        public long ImportId { get; set; }
    }
}
