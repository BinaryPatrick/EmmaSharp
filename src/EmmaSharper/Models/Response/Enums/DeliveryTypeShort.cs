using System.Runtime.Serialization;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
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
