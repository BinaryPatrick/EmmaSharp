using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmmaSharp
{
    public class SubscriptionBulk
    {
        [JsonProperty("member_ids")]
        public List<long> MemberIds { get; set; }

    }
}
