using Newtonsoft.Json;

namespace EmmaSharper
{

    public class SubscriptionMembers
    {
        [JsonProperty("member_id")]
        public long MemberId { get; set; }
    }
}
