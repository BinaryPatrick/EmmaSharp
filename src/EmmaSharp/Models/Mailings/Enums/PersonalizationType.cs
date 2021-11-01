using System.Runtime.Serialization;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    [JsonConverter(typeof(StringEnumJsonConverter))]
    public enum PersonalizationType
    {
        Unknown,

        [EnumMember(Value = "all")]
        All,

        [EnumMember(Value = "html")]
        Html,

        [EnumMember(Value = "plaintext")]
        PlainText,

        [EnumMember(Value = "subject")]
        Subject,
    }
}
