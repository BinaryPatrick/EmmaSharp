using System.Runtime.Serialization;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    [JsonConverter(typeof(StringEnumJsonConverter))]
    public enum WidgetType
    {
        Unknown,

        [EnumMember(Value = "text")]
        Text,

        [EnumMember(Value = "long")]
        LongInt,

        [EnumMember(Value = "checkbox")]
        Checkbox,

        [EnumMember(Value = "select multiple")]
        SelectMultiple,

        [EnumMember(Value = "check_multiple")]
        CheckMultiple,

        [EnumMember(Value = "radio")]
        Radio,

        [EnumMember(Value = "date")]
        Date,

        [EnumMember(Value = "select one")]
        SelectOne,

        [EnumMember(Value = "number")]
        Number,
    }
}
