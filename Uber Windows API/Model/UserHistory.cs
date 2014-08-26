namespace Uwapi.Model
{
    /// <summary>
    /// The user's lifetime activity with Uber
    /// </summary>
    public sealed class UserHistory
    {
        /// <summary>
        /// Position in pagination
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Number of Items to retrieve (100 max).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Total number of items available.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        /// <summary>
        /// Information including the pickup location, dropoff location, 
        /// request start time, request end time, and distance of 
        /// requests (in miles), as well as the product type that was requested.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "history")]
        public System.Collections.Generic.IList<UserActivity> UserActivities { get; set; }
    }
}