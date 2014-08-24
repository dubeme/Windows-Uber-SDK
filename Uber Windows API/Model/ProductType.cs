using System.Runtime.Serialization;

namespace Uwapi.Model
{
    /// <summary>
    /// The Uber products offered at a given location.
    /// </summary>
    public class ProductType
    {
        /// <summary>
        /// Unique identifier representing a specific product for a 
        /// given latitude & longitude. For example, uberX in San Francisco 
        /// will have a different product_id than uberX in Los Angeles.
        /// </summary>
        [DataMember(Name = "product_id", IsRequired = true)]
        public string ProductId { get; set; }

        /// <summary>
        /// Description of product.
        /// </summary>
        [DataMember(Name = "description", IsRequired = true)]
        public string Description { get; set; }

        /// <summary>
        /// Display name of product.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = true)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Capacity of product. For example, 4 people.
        /// </summary>
        [DataMember(Name = "capacity", IsRequired = true)]
        public int Capacity { get; set; }

        /// <summary>
        /// Image URL representing the product.
        /// </summary>
        [DataMember(Name = "image", IsRequired = true)]
        public string Image { get; set; }
    }
}