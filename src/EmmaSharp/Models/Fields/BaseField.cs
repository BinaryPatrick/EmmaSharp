using Newtonsoft.Json;

namespace EmmaSharp
{
    public class BaseField
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("field_type")]
        public FieldType FieldType { get; set; }

        [JsonProperty("widget_type")]
        public WidgetType WidgetType { get; set; }

        [JsonProperty("column_order")]
        public int? ColumnOrder { get; set; }
    }
}
