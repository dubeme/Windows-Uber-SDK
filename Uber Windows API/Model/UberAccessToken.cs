namespace Uwapi.Model
{
    /// <summary>
    /// Represents the uber access token
    /// </summary>
    public sealed class UberAccessToken
    {
        /// <summary>
        /// The access token to be used for making requests
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "access_token")]
        public string Token { get; set; }

        /// <summary>
        /// The type of token
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// When the token expires in seconds.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// The token to be used to refresh the Access Token.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// The scope the Access Token can reach.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }
    }
}