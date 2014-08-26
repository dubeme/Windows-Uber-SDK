namespace Uwapi.Model
{
    /// <summary>
    /// A user's activity with Uber
    /// </summary>
    public sealed class UserActivity
    {
        /// <summary>
        /// The activity ID.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "uuid")]
        public string uuid { get; set; }

        /// <summary>
        ///  
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "request_time")]
        public long RequestTime { get; set; }

        /// <summary>
        /// The id of the product that was used
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// The status of this activity.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The distance that was travelled in miles.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "distance")]
        public float Distance { get; set; }

        /// <summary>
        /// The start time.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "start_time")]
        public long StartTime { get; set; }

        /// <summary>
        /// The start location.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "start_location")]
        public UberLocation StartLocation { get; set; }

        /// <summary>
        /// The end time.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "end_time")]
        public long EndTime { get; set; }

        /// <summary>
        /// The end location.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "end_location")]
        public UberLocation EndLocation { get; set; }
    }
}