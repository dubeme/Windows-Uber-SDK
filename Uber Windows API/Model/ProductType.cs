namespace Uwapi.Model
{
    /// <summary>
    /// The Uber products offered at a given location.
    /// </summary>
    public sealed class ProductType
    {
        /// <summary>
        /// Unique identifier representing a specific product for a 
        /// given latitude & longitude. For example, uberX in San Francisco 
        /// will have a different product_id than uberX in Los Angeles.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// Description of product.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Display name of product.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Capacity of product. For example, 4 people.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "capacity")]
        public int Capacity { get; set; }

        /// <summary>
        /// Image URL representing the product.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "image")]
        public string Image { get; set; }
    }
}