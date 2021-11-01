using System.Runtime.Serialization;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    [JsonConverter(typeof(StringEnumJsonConverter))]
    public enum DeliveryTypeShort
    {
        Unknown,

        [EnumMember(Value = "d")]
        Delivered,

        [EnumMember(Value = "h")]
        Hard,

        [EnumMember(Value = "s")]
        Soft,
    }
}
