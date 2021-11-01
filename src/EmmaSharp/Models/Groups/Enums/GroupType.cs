using System.Runtime.Serialization;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    [JsonConverter(typeof(StringEnumJsonConverter))]
    public enum GroupType
    {
        Unknown,

        [EnumMember(Value = "g")]
        Group,

        [EnumMember(Value = "t")]
        Test,

        [EnumMember(Value = "h")]
        Hidden,

        [EnumMember(Value = "all")]
        All,
    }
}
