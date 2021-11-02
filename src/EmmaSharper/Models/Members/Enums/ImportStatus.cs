using System.Runtime.Serialization;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
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
