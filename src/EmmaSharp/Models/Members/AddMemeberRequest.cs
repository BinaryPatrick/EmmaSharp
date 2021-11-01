using System.Collections.Generic;

namespace EmmaSharp
{
    public class AddMemberRequest
    {
        public string MemberEmail { get; set; }
        public Dictionary<string, object> Fields { get; set; }
        public List<int> GroupIds { get; set; }
        public bool FieldTriggers { get; set; }

        public static AddMemberRequest From(string MemberEmail, Dictionary<string, object> Fields, List<int> GroupIds, bool FieldTriggers) => new AddMemberRequest()
        {
            MemberEmail = MemberEmail,
            Fields = Fields,
            GroupIds = GroupIds,
            FieldTriggers = FieldTriggers
        };
    }
}
