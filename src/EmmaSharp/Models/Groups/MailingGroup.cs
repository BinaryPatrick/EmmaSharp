using Newtonsoft.Json;

namespace EmmaSharp
{
    public class MailingGroup : Group
    {
        //Ugh. API names GroupName differently in Mailings than elsewhere.
        [JsonProperty("name")]
        public new string GroupName { get; set; }
    }
}
