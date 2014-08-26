namespace Uwapi.Model
{
    /// <summary>
    /// The estimated price range for a product offered at a given location
    /// </summary>
    public sealed class PriceEstimates
    {
        /// <summary>
        /// Unique identifier representing a specific product for a given 
        /// latitude & longitude. For example, uberX in San Francisco 
        /// will have a different product_id than uberX in Los Angeles.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// ISO 4217 currency code. http://en.wikipedia.org/wiki/ISO_4217
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Display name of product.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Formatted string of estimate in local currency of the start location. 
        /// Estimate could be a range, a single number (flat rate) or "Metered" for TAXI.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="estimate")]
        public string Estimate { get; set; }

        /// <summary>
        /// Lower bound of the estimated price.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="low_estimate")]
        public int LowEstimate { get; set; }

        /// <summary>
        /// Upper bound of the estimated price.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="high_estimate")]
        public int HighEstimate { get; set; }

        /// <summary>
        /// Expected surge multiplier. Surge is active if surge_multiplier is greater than 1. 
        /// Price estimate already factors in the surge multiplier.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="surge_multiplier")]
        public float SurgeMultiplier { get; set; }
    }
}