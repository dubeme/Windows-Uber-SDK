namespace Uwapi.ResponseModel
{
    public sealed class ProductTypeResponse
    {
        /// <summary>
        /// The Uber products offered at a given location.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="products")]
        public System.Collections.Generic.IList<Uwapi.Model.ProductType> Products { get; set; }
    }
}