using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmmaSharp
{
    public class MemberStatusShortList
    {
        [JsonProperty("member_status_id")]
        public List<MemberStatusShort> MemberStatusId { get; set; }
    }
}
