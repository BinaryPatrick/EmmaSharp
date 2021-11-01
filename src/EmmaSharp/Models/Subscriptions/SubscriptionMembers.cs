using Newtonsoft.Json;

namespace EmmaSharp
{

    public class SubscriptionMembers
    {
        [JsonProperty("member_id")]
        public long MemberId { get; set; }
    }
}
