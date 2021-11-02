using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class DeleteMembers
    {
        /// <summary>
        /// An array of member ids to delete.
        /// </summary>
        [JsonProperty("member_ids")]
        public List<long> MemberIds { get; set; }
    }
}
