using Newtonsoft.Json;

namespace EmmaSharper
{
    /// <summary>
    /// The class representing the returned properties when signing up a member.
    /// </summary>
    public class MemberSignup
    {
        /// <summary>
        /// The status of the member. The short status code will be returned as Active, Error, or Optout.
        /// </summary>
        [JsonProperty("status")]
        public MemberStatusShort Status { get; set; }

        /// <summary>
        /// The member id of the member.
        /// </summary>
        [JsonProperty("member_id")]
        public long? MemberId { get; set; }
    }
}
