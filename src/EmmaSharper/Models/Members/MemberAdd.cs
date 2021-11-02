using Newtonsoft.Json;

namespace EmmaSharper
{
    public class MemberAdd
    {
        [JsonProperty("status")]
        public MemberStatusShort Status { get; set; }

        [JsonProperty("member_id")]
        public long? MemberId { get; set; }

        [JsonProperty("added")]
        public bool Added { get; set; }
    }
}
