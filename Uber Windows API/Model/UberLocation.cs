using System.Runtime.Serialization;

namespace Uwapi.Model
{
    /// <summary>
    /// Represents a start/stop location
    /// </summary>
    public class UberLocation
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "address", IsRequired = true)]
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "latitude", IsRequired = true)]
        public float Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "longitude", IsRequired = true)]
        public float Longitude { get; set; }
    }
}