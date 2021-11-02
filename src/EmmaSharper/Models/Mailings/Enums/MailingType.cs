using System.Runtime.Serialization;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
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
