using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Uwapi.Model;
using Uwapi.ResponseModel;
using Windows.Foundation;
using Windows.Web.Http;

namespace Uwapi
{
    /// <summary>
    /// Represents a client for consuming the UBER api.
    /// </summary>
    public sealed class UberClient
    {
        #region Endpoints

        private const string ProductTypesEndpoint = "v1/products";
        private const string PricetEstimatsEndpoint = "v1/estimates/price";
        private const string TimeEstimatesEndpoint = "v1/estimates/time";
        private const string UserActivityEndpoint = "v1/history";
        private const string UserProfileEndpoint = "v1/me";

        #endregion Endpoints

        private string uberServerToken = string.Empty;
        private string uberClientId = string.Empty;
        private string uberSecret = string.Empty;

        public UberClient(string serverToken)
        {
            this.uberServerToken = serverToken;
        }

        /// <summary>
        /// Performs a request to the Uber API
        /// </summary>
        /// <param name="endpoint">The endpoint that is being called.</param>
        /// <param name="parameter">The parameters to be passed to the request.</param>
        /// <returns>The JSON result of the request.</returns>
        private IAsyncOperation<string> GetResponseJsonAsync(string endpoint, string parameter = null)
        {
            return Task.Run<string>(async () =>
            {
                // Try the request, if any exception return an empty string
                try
                {
                    StringBuilder url = new StringBuilder(string.Format("https://api.uber.com/{0}?server_token={1}", endpoint, this.uberServerToken));

                    if (parameter != null)
                    {
                        url.AppendFormat("&{0}", parameter);
                    }
                    return await (new HttpClient()).GetStringAsync(new Uri(url.ToString()));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

                return string.Empty;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// The Products endpoint returns information about the Uber products offered at a given location.
        /// </summary>
        /// <param name="latitude">Latitude component of location</param>
        /// <param name="longitude">Longitude component of location</param>
        /// <returns></returns>
        public IAsyncOperation<IList<ProductType>> GetProductTypesAsync(float latitude, float longitude)
        {
            return Task.Run<IList<ProductType>>(async () =>
            {
                string parameter = string.Format("latitude={0}&longitude={1}", latitude, longitude);

                string result = await this.GetResponseJsonAsync(ProductTypesEndpoint, parameter);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    try
                    {
                        var t = JsonConvert.DeserializeObject<ProductTypeResponse>(result);
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result)["products"].ToObject<List<ProductType>>();
                    }
                    catch (Exception) { }
                }

                return null;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// The Price Estimates endpoint returns an estimated price range for each product offered at a given location.
        /// </summary>
        /// <param name="start_latitude">Latitude component of start location</param>
        /// <param name="start_longitude">Longitude component of start location</param>
        /// <param name="end_latitude">Latitude component of end location</param>
        /// <param name="end_longitude">Longitude component of end location</param>
        /// <returns></returns>
        public IAsyncOperation<IList<PriceEstimates>> GetPriceEstimatesAsync(float start_latitude, float start_longitude, float end_latitude, float end_longitude)
        {
            return Task.Run<IList<PriceEstimates>>(async () =>
            {
                string parameters = string.Format("start_latitude={0}&start_longitude={1}&end_latitude={2}&end_longitude={3}", start_latitude, start_longitude, end_latitude, end_longitude);
                string result = await this.GetResponseJsonAsync(PricetEstimatsEndpoint, parameters);
                return null;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// The Time Estimates endpoint returns ETAs for all products offered at a given location, with the responses expressed as integers in seconds.
        /// </summary>
        /// <param name="start_latitude">Latitude component</param>
        /// <param name="start_longitude">Longitude component</param>
        /// <param name="customer_uuid">Unique customer identifier to be used for experience customization</param>
        /// <param name="product_id">Unique identifier representing a specific product for a given latitude & longitude</param>
        /// <returns></returns>
        public IAsyncOperation<IList<TimeEstimates>> GetTimeEstimatesAsync(float start_latitude, float start_longitude, string customer_uuid, string product_id)
        {
            return Task.Run<IList<TimeEstimates>>(async () =>
            {
                string parameter = string.Format("start_latitude={0}&start_longitude={1}&customer_uuid={2}&product_id={3}", start_latitude, start_longitude, customer_uuid, product_id);
                string result = await this.GetResponseJsonAsync(TimeEstimatesEndpoint, parameter);
                return null;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// The User Activity endpoint returns data about a user's lifetime activity with Uber.
        /// </summary>
        /// <param name="offset">Offset the list of returned results by this amount. Default is zero</param>
        /// <param name="limit">Number of items to retrieve. Default is 5, maximum is 100</param>
        /// <returns></returns>
        public IAsyncOperation<UserHistory> GetUserActivitiesAsync(int offset, int limit)
        {
            return Task.Run<UserHistory>(async () =>
            {
                string parameter = string.Format("offset={0}&limit={1}", offset, limit);
                string result = await this.GetResponseJsonAsync(UserActivityEndpoint, parameter);
                return null;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// The User Profile endpoint returns information about the Uber user that has authorized with the application.
        /// </summary>
        /// <returns></returns>
        public IAsyncOperation<UserProfile> GetUserProfileAsync()
        {
            return Task.Run<UserProfile>(async () =>
            {
                string result = await this.GetResponseJsonAsync(UserProfileEndpoint);
                return null;
            }).AsAsyncOperation();
        }
    }
}