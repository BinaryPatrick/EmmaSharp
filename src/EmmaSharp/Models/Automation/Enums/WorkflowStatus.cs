using System.Runtime.Serialization;

namespace EmmaSharp
{
    public enum WorkflowStatus
    {
        Unknown,

        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "inactive")]
        Inactive,

        [EnumMember(Value = "draft")]
        Draft,
    }
}

