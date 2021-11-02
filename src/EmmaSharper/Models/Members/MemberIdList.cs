using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class MemberIdList
    {
        [JsonProperty("member_ids")]
        public List<long> MemberIds { get; set; }
    }
}
