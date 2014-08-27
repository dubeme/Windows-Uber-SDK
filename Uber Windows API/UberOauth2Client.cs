using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwapi
{
    public sealed class UberOauth2Client
    {
        /// <summary>
        /// Get the url that the user will use to login to there uber account and then authorize your app.
        /// </summary>
        /// <param name="clientID">The client ID of your app</param>
        /// <param name="scope">Comma delimited list of grant scopes you would like to have permission to access on behalf of the user.</param>
        /// <param name="state">State which will be passed back to you to prevent tampering.</param>
        /// <param name="redirectURL">
        ///     The URI we will redirect back to after an authorization by the resource owner. 
        ///     The base of the URI must match the redirect_uri used during the registration of your application.
        /// </param>
        /// <returns></returns>
        public static Uri GetAuthorizationURL(string clientID, string scope, string state, string redirectURL)
        {
            StringBuilder url = new StringBuilder("https://login.uber.com/oauth/authorize?response_type=code");

            if (!string.IsNullOrWhiteSpace(clientID))
            {
                url.AppendFormat("&client_id={0}", clientID);
            }

            if (!string.IsNullOrWhiteSpace(scope))
            {
                url.AppendFormat("&scope ={0}", scope);
            }

            if (!string.IsNullOrWhiteSpace(state))
            {
                url.AppendFormat("&state ={0}", state);
            }

            if (!string.IsNullOrWhiteSpace(redirectURL))
            {
                url.AppendFormat("&redirect_uri={0}", redirectURL);
            }

            return new Uri(url.ToString());
        }


    }
}