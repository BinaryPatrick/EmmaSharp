using System;
using Newtonsoft.Json;

namespace EmmaSharp.Internals
{
    internal class RawStringJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(string);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => reader.Value;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => writer.WriteRawValue((string)value);
    }
}