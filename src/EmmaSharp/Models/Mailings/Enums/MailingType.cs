using System.Runtime.Serialization;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    [JsonConverter(typeof(StringEnumJsonConverter))]
    public enum MailingType
    {
        Unknown,

        [EnumMember(Value = "m")]
        Standard,

        [EnumMember(Value = "t")]
        Test,

        [EnumMember(Value = "r")]
        Trigger,

        [EnumMember(Value = "s")]
        Split,

        [EnumMember(Value = "c")]
        ContentSplit,
    }
}
