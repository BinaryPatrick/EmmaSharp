using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmmaSharper
{
    /// <summary>
    /// Remove multiple members from groups.
    /// </summary>
    public class RemoveMemberGroups
    {
        /// <summary>
        /// Member ids to remove from the given groups.
        /// </summary>
        [JsonProperty("member_ids")]
        public List<long> MemberIds { get; set; }

        /// <summary>
        /// Group ids from which to remove the given members.
        /// </summary>
        [JsonProperty("group_ids")]
        public List<int> GroupIds { get; set; }
    }
}
