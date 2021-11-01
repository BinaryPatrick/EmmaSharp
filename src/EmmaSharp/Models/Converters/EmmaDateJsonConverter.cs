using System;
using Newtonsoft.Json;

namespace EmmaSharp.Internals
{
    /// <summary>Custom date parser to handle Emma's unique date format</summary>
    /// <remarks>Date formate is "@D:2014-11-26T11:40:55"</remarks>
    internal class EmmaDateJsonConverter : JsonConverter
    {
        /// <summary>Writes the JSON representation of the object. Writes a DateTime value that Emma expects.</summary>
        /// <param name="writer">Instance of the JsonWriter class.</param>
        /// <param name="value">The value of the Date to be serialized.</param>
        /// <param name="serializer">Instance of the JsonSearlizer class.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTime date = (DateTime)value;
            writer.WriteValue($"@D:{date:s}"); // Deal with this, ugh: "@D:2014-11-26T11:40:55"
        }

        /// <summary>Reads the JSON representation of the object. In this case a DateTime that C# can parse.</summary>
        /// <param name="reader">Instance of the JsonReader class.</param>
        /// <param name="objectType">The type of object to read.</param>
        /// <param name="existingValue">The existing object value.</param>
        /// <param name="serializer">Instance of the JsonSearlizer class.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value is null)
            {
                return null;
            }

            string date = reader.Value.ToString().Replace("@D:", "");
            DateTime? result = DateTime.TryParse(date, out DateTime parsed) ? (DateTime?)parsed : default;

            return result;
        }

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>True if this instance can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(Type objectType)
            => false;
    }
}
