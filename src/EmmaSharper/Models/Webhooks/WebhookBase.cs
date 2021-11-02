﻿using Newtonsoft.Json;

namespace EmmaSharper
{
    /// <summary>
    /// Common Properties to all Webhook classes.
    /// </summary>
    public class WebhookBase
    {
        /// <summary>
        /// The name of an event to register this webhook for
        /// </summary>
        [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
        public string Event { get; set; }

        /// <summary>
        /// The URL to call when the event happens
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// The method to use when calling the webhook. Can be GET or POST. Defaults to POST.
        /// </summary>
        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public WebhookMethod Method { get; set; }
    }
}
