using System.Runtime.Serialization;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
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