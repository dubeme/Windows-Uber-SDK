namespace Uwapi.Model
{
    /// <summary>
    /// Represents a start/stop location
    /// </summary>
    public sealed class UberLocation
    {
        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "longitude")]
        public float Longitude { get; set; }
    }
}