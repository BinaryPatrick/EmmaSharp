using Newtonsoft.Json;

namespace EmmaSharper
{
    public class UpdateMailing : MailingInfo
    {
        [JsonProperty("plaintext")]
        public string Plaintext { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }
    }
}
