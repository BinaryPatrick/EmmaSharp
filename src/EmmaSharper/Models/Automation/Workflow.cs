using System;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class Workflow
    {
        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public WorkflowStatus Status { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}

