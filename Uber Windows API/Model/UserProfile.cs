namespace Uwapi.Model
{
    /// <summary>
    /// The information about the Uber user that has authorized with the application.
    /// </summary>
    public sealed class UserProfile
    {
        /// <summary>
        /// First name of the Uber user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the Uber user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Email address of the Uber user
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="email")]
        public string Email { get; set; }

        /// <summary>
        /// Image URL of the Uber user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="picture")]
        public string Picture { get; set; }

        /// <summary>
        /// Promo code of the Uber user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="promo_code")]
        public string PromoCode { get; set; }
    }
}