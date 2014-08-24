
using System.Runtime.Serialization;
namespace Uwapi.Model
{
    /// <summary>
    /// A user's activity with Uber
    /// </summary>
    public class UserActivity
    {
        /// <summary>
        /// The activity ID.
        /// </summary>
        [DataMember(Name = "uuid", IsRequired = true)]
        public string uuid { get; set; }

        /// <summary>
        ///  
        /// </summary>
        [DataMember(Name = "request_time", IsRequired = true)]
        public long RequestTime { get; set; }

        /// <summary>
        /// The id of the product that was used
        /// </summary>
        [DataMember(Name = "product_id", IsRequired = true)]
        public string ProductId { get; set; }

        /// <summary>
        /// The status of this activity.
        /// </summary>
        [DataMember(Name = "status", IsRequired = true)]
        public string Status { get; set; }

        /// <summary>
        /// The distance that was travelled in miles.
        /// </summary>
        [DataMember(Name = "distance", IsRequired = true)]
        public float Distance { get; set; }

        /// <summary>
        /// The start time.
        /// </summary>
        [DataMember(Name = "start_time", IsRequired = true)]
        public long StartTime { get; set; }

        /// <summary>
        /// The start location.
        /// </summary>
        [DataMember(Name = "start_location", IsRequired = true)]
        public UberLocation StartLocation { get; set; }

        /// <summary>
        /// The end time.
        /// </summary>
        [DataMember(Name = "end_time", IsRequired = true)]
        public long EndTime { get; set; }

        /// <summary>
        /// The end location.
        /// </summary>
        [DataMember(Name = "end_location", IsRequired = true)]
        public UberLocation EndLocation { get; set; }
    }
}