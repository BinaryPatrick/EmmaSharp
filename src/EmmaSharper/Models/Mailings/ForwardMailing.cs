﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmmaSharper
{
    /// <summary>
    /// Forward a previous message to additional recipients. If these recipients are not already in the audience, they will be added with a status of FORWARDED.
    /// </summary>
    public class ForwardMailing
    {
        /// <summary>
        /// An array of email addresses to which to forward the specified message.
        /// </summary>
        [JsonProperty("recipient_emails")]
        public List<string> RecipientEmails { get; set; }

        /// <summary>
        /// A note to include in the forward. This note will be HTML encoded and is limited to 500 characters.
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; set; }
    }
}
