using System;
using System.Collections.Generic;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class ResponseGeneric
    {
        [JsonProperty("fields")]
        public Dictionary<string, object> Fields { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty("member_id")]
        public long? MemberId { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("member_since")]
        public DateTime? MemberSince { get; set; }

        [JsonProperty("email_domain")]
        public string EmailDomain { get; set; }

        [JsonProperty("email_user")]
        public string EmailUser { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("member_status_id")]
        public MemberStatusShort MemberStatusId { get; set; }
    }

    public class ResponseClicks : ResponseGeneric
    {
        [JsonProperty("link_id")]
        public int? LinkId { get; set; }
    }

    public class ResponseDeliveries : ResponseGeneric
    {
        [JsonProperty("delivery_type")]
        public DeliveryType DeliveryType { get; set; }

        [JsonProperty("mailing_id")]
        public long? MailingId { get; set; }

        [JsonProperty("mailing_name")]
        public string MailingName { get; set; }
    }

    public class ResponseForwards : ResponseGeneric
    {
        [JsonProperty("forward_mailing_id")]
        public long? ForwardMailingId { get; set; }
    }

    public class ResponseSignups : ResponseGeneric
    {
        [JsonProperty("ref_member_id")]
        public int? ReferingMemberId { get; set; }

        [JsonProperty("mailing_mailing_id")]
        public long? MailingMailingId { get; set; }
    }
}
