using System;
using System.Collections.Generic;
using EmmaSharper.Internals;
using Newtonsoft.Json;

namespace EmmaSharper
{
    public class Import
    {
        [JsonProperty("import_id")]
        public long? ImportId { get; set; }

        [JsonProperty("status")]
        public ImportStatus? Status { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("import_started")]
        public DateTime? ImportStarted { get; set; }

        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("num_members_updated")]
        public int? NumMembersUpdated { get; set; }

        [JsonProperty("source_filename")]
        public string SourceFilename { get; set; }

        [JsonProperty("fields_updated")]
        public List<Field> FieldsUpdated { get; set; }

        [JsonProperty("num_members_added")]
        public int? NumMembersAdded { get; set; }

        [JsonConverter(typeof(EmmaDateJsonConverter))]
        [JsonProperty("import_finished")]
        public DateTime? ImportFinished { get; set; }

        [JsonProperty("groups_updated")]
        public List<Group> GroupsUpdated { get; set; }

        [JsonProperty("num_skipped")]
        public int? NumSkipped { get; set; }

        [JsonProperty("num_duplicates")]
        public int? NumDuplicates { get; set; }
    }
}
