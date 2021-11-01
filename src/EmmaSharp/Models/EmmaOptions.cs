namespace EmmaSharp
{
    /// <summary>Emma configuration options</summary>
    public class EmmaOptions
    {
        private const string BASE_URL = "https://api.e2ma.net";

        /// <summary>Represents the default Emma API endpoint</summary>
        /// <remarks><i>Default is <see href="https://api.e2ma.net"/></i></remarks>
        public string BaseUrl { get; set; } = BASE_URL;

        /// <summary>Unique Emma account identifier</summary>
        public string AccountId { get; set; }

        /// <summary>Emma public key</summary>
        public string PublicKey { get; set; }

        /// <summary>Emma private key</summary>
        public string SecretKey { get; set; }
    }
}
