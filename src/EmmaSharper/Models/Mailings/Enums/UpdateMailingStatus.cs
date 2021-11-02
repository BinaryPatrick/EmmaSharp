using System.Runtime.Serialization;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    [JsonConverter(typeof(StringEnumJsonConverter))]
    public enum UpdateMailingStatus
    {
        Unknown,

        [EnumMember(Value = "canceled")]
        Canceled,

        [EnumMember(Value = "paused")]
        Paused,

        [EnumMember(Value = "ready")]
        Ready,
    }
}