using System.Runtime.Serialization;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    [JsonConverter(typeof(StringEnumJsonConverter))]
    public enum MemberStatusShort
    {
        Unknown,

        [EnumMember(Value = "a")]
        Active,

        [EnumMember(Value = "o")]
        Optout,

        [EnumMember(Value = "e")]
        Error,

        [EnumMember(Value = "f")]
        Forwarded,
    }
}
