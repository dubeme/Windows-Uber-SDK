using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        #region Constants

        private const string HISTORY_SCOPE = "history";
        private const string PROFILE_SCOPE = "profile";
        private const string PROFILE_HISTORY_SCOPE = "history,profile";

        #endregion Constants

        #region Endpoints

        private const string ProductTypesEndpoint = "v1/products";
        private const string PricetEstimatsEndpoint = "v1/estimates/price";
        private const string TimeEstimatesEndpoint = "v1/estimates/time";
        private const string UserActivityEndpoint = "v1/history";
        private const string UserProfileEndpoint = "v1/me";

        #endregion Endpoints

        #region Fields

        private string uberServerToken = string.Empty;
        private string uberClientId = string.Empty;
        private string uberRedirectUrl = string.Empty;
        private string uberClientSecret = string.Empty;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverToken">The secrete token for your app</param>
        /// <param name="clientId">The client ID of your app</param>
        /// <param name="redirectURL">
        ///     The URI we will redirect back to after an authorization by the resource owner. 
        ///     The base of the URI must match the redirect_uri used during the registration of your application.
        /// </param>
        /// <param name="clientSecret">The 40 character long super secret code for your app.</param>
        public UberClient(string serverToken, string clientId, string redirectURL, string clientSecret)
        {
            this.uberServerToken = serverToken;
            this.uberClientId = clientId;
            this.uberRedirectUrl = redirectURL;
            this.uberClientSecret = clientSecret;
        }

        #endregion Constructor

        #region Uber Endpoints

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
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("latitude",latitude.ToString()),
                    new KeyValuePair<string, string>("longitude",longitude.ToString())
                };

                string result = await this.GetResponseJsonAsync(ProductTypesEndpoint, parameters);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<ProductTypeResponse>(result).Products;
                    }
                    catch (Exception) { }
                }

                return null;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// The Price Estimates endpoint returns an estimated price range for each product offered at a given location.
        /// </summary>
        /// <param name="startLatitude">Latitude component of start location</param>
        /// <param name="startLongitude">Longitude component of start location</param>
        /// <param name="endLatitude">Latitude component of end location</param>
        /// <param name="endLongitude">Longitude component of end location</param>
        /// <returns></returns>
        public IAsyncOperation<IList<PriceEstimates>> GetPriceEstimatesAsync(float startLatitude, float startLongitude, float endLatitude, float endLongitude)
        {
            return Task.Run<IList<PriceEstimates>>(async () =>
            {
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("start_latitude",startLatitude.ToString()),
                    new KeyValuePair<string, string>("start_longitude",startLongitude.ToString()),
                    new KeyValuePair<string, string>("end_latitude",endLatitude.ToString()),
                    new KeyValuePair<string, string>("end_longitude",endLongitude.ToString())
                };

                string result = await this.GetResponseJsonAsync(PricetEstimatsEndpoint, parameters);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<PriceEstimatesResponse>(result).Prices;
                    }
                    catch (Exception) { }
                }

                return null;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// The Time Estimates endpoint returns ETAs for all products offered at a given location, with the responses expressed as integers in seconds.
        /// </summary>
        /// <param name="startLatitude">Latitude component</param>
        /// <param name="startLongitude">Longitude component</param>
        /// <param name="customerUUID">Unique customer identifier to be used for experience customization</param>
        /// <param name="productId">Unique identifier representing a specific product for a given latitude and longitude</param>
        /// <returns></returns>
        public IAsyncOperation<IList<TimeEstimates>> GetTimeEstimatesAsync(float startLatitude, float startLongitude, string customerUUID, string productId)
        {
            return Task.Run<IList<TimeEstimates>>(async () =>
            {
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("start_latitude",startLatitude.ToString()),
                    new KeyValuePair<string, string>("start_longitude",startLongitude.ToString())
                };

                if (!string.IsNullOrWhiteSpace(customerUUID))
                {
                    parameters.Add(new KeyValuePair<string, string>("customer_uuid", customerUUID));
                }

                if (!string.IsNullOrWhiteSpace(productId))
                {
                    parameters.Add(new KeyValuePair<string, string>("product_id", productId));
                }

                string result = await this.GetResponseJsonAsync(TimeEstimatesEndpoint, parameters);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<TimeEstimatesResponse>(result).Times;
                    }
                    catch (Exception) { }
                }

                return null;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// The User Activity endpoint returns data about a user's lifetime activity with Uber.
        /// </summary>
        /// <param name="offset">Offset the list of returned results by this amount. Default is zero</param>
        /// <param name="limit">Number of items to retrieve. Default is 5, maximum is 100</param>
        /// <param name="accessToken">The access token for making the request</param>
        /// <returns></returns>
        public IAsyncOperation<UserActivities> GetUserActivitiesAsync(int offset, int limit, string accessToken)
        {
            return Task.Run<UserActivities>(async () =>
            {
                // Force to be within [5, 100]
                limit = Math.Min(Math.Max(5, limit), 100);
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("offset",Math.Max(0, offset).ToString()),
                    new KeyValuePair<string, string>("limit",limit.ToString())
                };

                string result = await this.GetResponseJsonAsync(UserActivityEndpoint, parameters, accessToken);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<UserActivities>(result);
                    }
                    catch (Exception) { }
                }

                return null;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// The User Profile endpoint returns information about the Uber user that has authorized with the application.
        /// </summary>
        /// <returns></returns>
        public IAsyncOperation<UserProfile> GetUserProfileAsync(string accessToken)
        {
            return Task.Run<UserProfile>(async () =>
            {
                string result = await this.GetResponseJsonAsync(UserProfileEndpoint, accessToken: accessToken, ignoreParameters: true);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<UserProfile>(result);
                    }
                    catch (Exception) { }
                }

                return null;
            }).AsAsyncOperation();
        }

        #endregion Uber Endpoints

        #region Http stuff

        /// <summary>
        /// Performs a request to the Uber API
        /// </summary>
        /// <param name="endpoint">The endpoint that is being called.</param>
        /// <param name="parameters">The parameters to be passed to the request.</param>
        /// <param name="accessToken">The access token for authorizing the request.</param>
        /// <param name="ignoreParameters">Indicates whether the url should have a parameter.</param>
        /// <returns>The JSON result of the request.</returns>
        private IAsyncOperation<string> GetResponseJsonAsync(string endpoint, IList<KeyValuePair<string, string>> parameters = null, string accessToken = null, bool ignoreParameters = false)
        {
            return Task.Run<string>(async () =>
            {
                // Try the request, if any exception return an empty string
                try
                {
                    if (!ignoreParameters && parameters == null)
                    {
                        parameters = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("server_token", this.uberServerToken)
                        };
                    }

                    // The base url
                    string baseURL = string.Format("https://api.uber.com/{0}", endpoint);

                    HttpClient client = new HttpClient(new Windows.Web.Http.Filters.HttpBaseProtocolFilter
                    {
                        AllowUI = false
                    });

                    // If thers an access token then include it in the header of the request
                    if (!string.IsNullOrWhiteSpace(accessToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new Windows.Web.Http.Headers.HttpCredentialsHeaderValue("Bearer", accessToken);
                    }

                    // Make the request and return what ever the server returns
                    return await client.GetStringAsync(new Uri(AppendParameterToUrl(baseURL, parameters)));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

                return string.Empty;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// Get the url that the user will use to login to there uber account and then authorize your app.
        /// </summary>
        /// <param name="scope">Comma delimited list of grant scopes you would like to have permission to access on behalf of the user.</param>
        /// <param name="state">State which will be passed back to you to prevent tampering.</param>
        /// <returns></returns>
        public Uri GetAuthorizationURL(UberAccessScope scope, string state)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(this.uberClientId))
            {
                parameters.Add(new KeyValuePair<string, string>("client_id", this.uberClientId));
            }

            if (scope != UberAccessScope.Unknown)
            {
                switch (scope)
                {
                    case UberAccessScope.Profile:
                        parameters.Add(new KeyValuePair<string, string>("scope", PROFILE_SCOPE));
                        break;
                    case UberAccessScope.History:
                        parameters.Add(new KeyValuePair<string, string>("scope", HISTORY_SCOPE));
                        break;
                    case UberAccessScope.History | UberAccessScope.Profile:
                        parameters.Add(new KeyValuePair<string, string>("scope", PROFILE_HISTORY_SCOPE));
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(state))
            {
                parameters.Add(new KeyValuePair<string, string>("state", state));
            }

            if (!string.IsNullOrWhiteSpace(this.uberRedirectUrl))
            {
                parameters.Add(new KeyValuePair<string, string>("redirect_uri", this.uberRedirectUrl));
            }

            parameters.Add(new KeyValuePair<string, string>("response_type", "code"));
            string baseURL = "https://login.uber.com/oauth/authorize";

            return new Uri(AppendParameterToUrl(baseURL, parameters));
        }

        /// <summary>
        /// Get an access token to be used for making requests
        /// </summary>
        /// <param name="authorizationCode">The authorization code returned by Uber</param>
        /// <returns>An object representing the access token</returns>
        public IAsyncOperation<UberAccessToken> ExchangeAuthorizationCodeForAccessToken(string authorizationCode)
        {
            return Task.Run<UberAccessToken>(async () =>
            {
                try
                {
                    var requestData = new HttpFormUrlEncodedContent(new[] 
                    {
                        new KeyValuePair<string, string>("client_secret", this.uberClientSecret),
                        new KeyValuePair<string, string>("client_id", this.uberClientId),
                        new KeyValuePair<string, string>("grant_type", "authorization_code"),
                        new KeyValuePair<string, string>("redirect_uri", this.uberRedirectUrl),
                        new KeyValuePair<string, string>("code", authorizationCode)
                    });

                    HttpResponseMessage response = await (new HttpClient()).PostAsync(new Uri("https://login.uber.com/oauth/token"), requestData);
                    return JsonConvert.DeserializeObject<UberAccessToken>(await response.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

                return null;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// Refresh an expired access token.
        /// </summary>
        /// <param name="refreshToken">The refresh token. This is part of the access token object</param>
        /// <returns>A new access token.</returns>
        public IAsyncOperation<UberAccessToken> RefreshAccessToken(string refreshToken)
        {
            return Task.Run<UberAccessToken>(async () =>
            {
                try
                {
                    var requestData = new HttpFormUrlEncodedContent(new[] 
                    {
                        new KeyValuePair<string, string>("client_secret", this.uberClientSecret),
                        new KeyValuePair<string, string>("client_id", this.uberClientId),
                        new KeyValuePair<string, string>("grant_type", "refresh_token"),
                        new KeyValuePair<string, string>("redirect_uri", this.uberRedirectUrl),
                        new KeyValuePair<string, string>("refresh_token", refreshToken)
                    });

                    HttpResponseMessage response = await (new HttpClient()).PostAsync(new Uri("https://login.uber.com/oauth/token"), requestData);
                    JsonConvert.DeserializeObject<UberAccessToken>(await response.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

                return null;
            }).AsAsyncOperation();
        }

        /// <summary>
        /// Encodes the parameter, then append it to the url
        /// </summary>
        /// <param name="baseURL">The base url</param>
        /// <param name="parameters">The parameters</param>
        /// <param name="encodeParameters">Indicates whether the parameters should be encoded</param>
        /// <returns>The url with the encoded parameters appended to it</returns>
        private static string AppendParameterToUrl(string baseURL, IList<KeyValuePair<string, string>> parameters, bool encodeParameters = true)
        {
            StringBuilder url = new StringBuilder(baseURL);

            // Setup parameters
            if (parameters != null && parameters.Any())
            {
                // If no Question mark
                if (!baseURL.EndsWith("?"))
                {
                    url.Append("?");
                }

                StringBuilder _params = new StringBuilder();

                foreach (var parameter in parameters)
                {
                    if (encodeParameters)
                    {
                        _params.AppendFormat("&{0}={1}", parameter.Key, Uri.EscapeDataString(parameter.Value.Replace(" ","%20")));
                    }
                    else
                    {
                        _params.AppendFormat("&{0}={1}", parameter.Key, parameter.Value);
                    }
                }

                url.Append(_params.Remove(0, 1).ToString());
            }

            return url.ToString();
        }

        #endregion Http stuff
    }
}