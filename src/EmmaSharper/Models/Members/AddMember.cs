﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmmaSharper
{
    /// <summary>Parameters to add a single member to an audience. Group Ids and Field Triggers are optional</summary>
    public class AddMember
    {
        /// <inheritdoc cref="object.Object"/>
        public AddMember()
        {
            GroupIds = new List<int>();
        }

        /// <summary>
        /// Email address of member to add or update
        /// </summary>
        [JsonProperty("email")]
        public string MemberEmail { get; set; }

        /// <summary>
        /// Names and values of user-defined fields to update
        /// </summary>
        [JsonProperty("fields")]
        public Dictionary<string, object> Fields { get; set; }

        /// <summary>
        /// Optional. Add imported members to this list of groups.
        /// </summary>
        [JsonProperty("group_ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> GroupIds { get; set; }

        /// <summary>
        /// Optional. Fires related field change auto-responders when set to true.
        /// </summary>
        [JsonProperty("field_triggers", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FieldTriggers { get; set; }
    }
}
