using System.Runtime.Serialization;

namespace Uwapi.Model
{
    /// <summary>
    /// The ETA for a product offered at a given location
    /// </summary>
    public class TimeEstimate
    {
        /// <summary>
        /// Unique identifier representing a specific product for a given latitude & longitude. 
        /// For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles.
        /// </summary>
        [DataMember(Name = "product_id", IsRequired = true)]
        public string ProductId { get; set; }

        /// <summary>
        /// Display name of product.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = true)]
        public string DisplayName { get; set; }

        /// <summary>
        /// ETA for the product (in seconds). Always show estimate in minutes.
        /// </summary>
        [DataMember(Name = "estimate", IsRequired = true)]
        public int Estimate { get; set; }
    }
}