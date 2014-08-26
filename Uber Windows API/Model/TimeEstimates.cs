namespace Uwapi.Model
{
    /// <summary>
    /// The ETA for a product offered at a given location
    /// </summary>
    public sealed class TimeEstimates
    {
        /// <summary>
        /// Unique identifier representing a specific product for a given latitude & longitude. 
        /// For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// Display name of product.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// ETA for the product (in seconds). Always show estimate in minutes.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "estimate")]
        public int Estimate { get; set; }
    }
}