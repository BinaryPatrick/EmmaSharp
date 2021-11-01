using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmmaSharp
{
    public class Mailing : MailingBase
    {
        [JsonProperty("recipient_groups")]
        public List<MailingGroup> RecipientGroups { get; set; }

        [JsonProperty("heads_up_emails")]
        public List<Email> HeadsUpEmails { get; set; }

        [JsonProperty("links")]
        public List<Link> Links { get; set; }

        [JsonProperty("public_webview_url")]
        public string PublicWebviewUrl { get; set; }

        [JsonProperty("recipient_searches")]
        public List<Search> RecipientSearches { get; set; }

        [JsonProperty("recipient_members")]
        public List<Member> RecipientMembers { get; set; }

        [JsonProperty("plaintext")]
        public string Plaintext { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }
    }
}
