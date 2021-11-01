using System.Runtime.Serialization;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    [JsonConverter(typeof(StringEnumJsonConverter))]
    public enum MailingStatus
    {
        Unknown,

        [EnumMember(Value = "p")]
        Pending,

        [EnumMember(Value = "a")]
        Paused,

        [EnumMember(Value = "s")]
        Sending,

        [EnumMember(Value = "x")]
        Canceled,

        [EnumMember(Value = "c")]
        Complete,

        [EnumMember(Value = "f")]
        Failed,
    }
}
