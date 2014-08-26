namespace Uwapi.ResponseModel
{
    public sealed class PriceEstimatesResponse
    {
        /// <summary>
        /// The estimated price range for each product offered at a given location.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName ="prices")]
        public System.Collections.Generic.IList<Uwapi.Model.PriceEstimates> Prices { get; set; }
    }
}