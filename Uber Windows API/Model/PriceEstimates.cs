using System.Runtime.Serialization;

namespace Uwapi.Model
{
    /// <summary>
    /// The estimated price range for a product offered at a given location
    /// </summary>
    public class PriceEstimates
    {
        /// <summary>
        /// Unique identifier representing a specific product for a given 
        /// latitude & longitude. For example, uberX in San Francisco 
        /// will have a different product_id than uberX in Los Angeles.
        /// </summary>
        [DataMember(Name = "product_id", IsRequired = true)]
        public string ProductId { get; set; }

        /// <summary>
        /// ISO 4217 currency code. http://en.wikipedia.org/wiki/ISO_4217
        /// </summary>
        [DataMember(Name = "currency_code", IsRequired = true)]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Display name of product.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = true)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Formatted string of estimate in local currency of the start location. 
        /// Estimate could be a range, a single number (flat rate) or "Metered" for TAXI.
        /// </summary>
        [DataMember(Name = "estimate", IsRequired = true)]
        public string Estimate { get; set; }

        /// <summary>
        /// Lower bound of the estimated price.
        /// </summary>
        [DataMember(Name = "low_estimate", IsRequired = true)]
        public int LowEstimate { get; set; }

        /// <summary>
        /// Upper bound of the estimated price.
        /// </summary>
        [DataMember(Name = "high_estimate", IsRequired = true)]
        public int HighEstimate { get; set; }

        /// <summary>
        /// Expected surge multiplier. Surge is active if surge_multiplier is greater than 1. 
        /// Price estimate already factors in the surge multiplier.
        /// </summary>
        [DataMember(Name = "surge_multiplier", IsRequired = true)]
        public float SurgeMultiplier { get; set; }
    }
}