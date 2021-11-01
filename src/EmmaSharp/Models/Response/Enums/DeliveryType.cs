using System.Runtime.Serialization;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    [JsonConverter(typeof(StringEnumJsonConverter))]
    public enum DeliveryType
    {
        Unknown,

        [EnumMember(Value = "all")]
        All,

        [EnumMember(Value = "delivered")]
        Delivered,

        [EnumMember(Value = "bounced")]
        Bounced,

        [EnumMember(Value = "hard")]
        Hard,

        [EnumMember(Value = "soft")]
        Soft,
    }
}
