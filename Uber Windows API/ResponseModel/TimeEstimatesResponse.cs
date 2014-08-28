namespace Uwapi.ResponseModel
{
    /// <summary>
    /// Represents the time estimates returned by uber.
    /// </summary>
    public sealed class TimeEstimatesResponse
    {
        /// <summary>
        /// The ETAs for all products offered at a given location.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="times")]
        public System.Collections.Generic.IList<Uwapi.Model.TimeEstimates> Times { get; set; }
    }
}