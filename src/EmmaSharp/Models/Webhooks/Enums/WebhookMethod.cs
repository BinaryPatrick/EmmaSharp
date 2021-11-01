using System.Runtime.Serialization;
using EmmaSharp.Internals;
using Newtonsoft.Json;

namespace EmmaSharp
{
    /// <summary>Webhook method enumeration</summary>
    [JsonConverter(typeof(StringEnumJsonConverter))]
    public enum WebhookMethod
    {
        Unknown,

        /// <summary>
        /// Webhook uses HTTP GET
        /// </summary>
        [EnumMember(Value = "GET")]
        Get,

        /// <summary>
        /// Webhook uses HTTP POST
        /// </summary>
        [EnumMember(Value = "POST")]
        Post,
    }
}
