using Newtonsoft.Json;

namespace EmmaSharp
{
    public class CreateField : BaseField
    {
        [JsonProperty("shortcut_name")]
        public string ShortcutName { get; set; }

        public CreateField()
        {
            ShortcutName = ShortcutName;
            DisplayName = DisplayName;
            FieldType = FieldType.Text;
            WidgetType = WidgetType.Text;
            ColumnOrder = 0;
        }
    }
}
