using Newtonsoft.Json;

namespace EmmaSharper
{
    public class MailingGroup : Group
    {
        //Ugh. API names GroupName differently in Mailings than elsewhere.
        [JsonProperty("name")]
        public new string GroupName { get; set; }
    }
}
