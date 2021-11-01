using Newtonsoft.Json;

namespace EmmaSharp
{
    public class SignupForm
    {
        [JsonProperty("id")]
        public int? SignupFormId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
