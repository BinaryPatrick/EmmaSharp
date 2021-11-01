using System.Runtime.Serialization;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    [JsonConverter(typeof(StringEnumJsonConverter))]
    public enum ImportStatus
    {
        Unknown,

        [EnumMember(Value = "o")]
        Okay,

        [EnumMember(Value = "e")]
        Error,

        [EnumMember(Value = "q")]
        Queued,
    }
}
