﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Globalization;

namespace Mvc3Layout.Models
{

    /// <summary>
    /// Contains Constants.
    /// </summary>
    internal class Constants
    {
        /// <summary>
        /// OAuth EndPoints.
        /// </summary>
        internal class OauthEndPoints
        {
            /// <summary>
            /// Url Request Token
            /// </summary>
            internal static string UrlRequestToken = ConfigurationManager.AppSettings["Url_Request_Token"] != null ?
                ConfigurationManager.AppSettings["Url_Request_Token"].ToString(CultureInfo.InvariantCulture) : "/get_request_token";

            /// <summary>
            /// Url Access Token
            /// </summary>
            internal static string UrlAccessToken = ConfigurationManager.AppSettings["Url_Access_Token"] != null ?
                ConfigurationManager.AppSettings["Url_Access_Token"].ToString(CultureInfo.InvariantCulture) : "/get_access_token";

            /// <summary>
            /// Federation base url.
            /// </summary>
            internal static string IdFedOAuthBaseUrl = ConfigurationManager.AppSettings["Intuit_OAuth_BaseUrl"] != null ?
                ConfigurationManager.AppSettings["Intuit_OAuth_BaseUrl"].ToString(CultureInfo.InvariantCulture) : "https://oauth.intuit.com/oauth/v1";

            /// <summary>
            /// Authorize url.
            /// </summary>
            internal static string AuthorizeUrl = ConfigurationManager.AppSettings["Intuit_Workplace_AuthorizeUrl"] != null ?
                ConfigurationManager.AppSettings["Intuit_Workplace_AuthorizeUrl"].ToString(CultureInfo.InvariantCulture) : "https://workplace.intuit.com/Connect/Begin";
        }

        /// <summary>
        /// Intuit Anywhere Endpoints.
        /// </summary>
        internal class IaEndPoints
        {
            /// <summary>
            /// BlueDot Menu Url.
            /// </summary>
            internal static string BlueDotAppMenuUrl = ConfigurationManager.AppSettings["BlueDot_AppMenuUrl"] != null ?
                ConfigurationManager.AppSettings["BlueDot_AppMenuUrl"].ToString(CultureInfo.InvariantCulture) : "https://workplace.intuit.com/api/v1/Account/AppMenu";

            /// <summary>
            /// Disconnect url.
            /// </summary>
            internal static string DisconnectUrl = ConfigurationManager.AppSettings["DisconnectUrl"] != null ?
                ConfigurationManager.AppSettings["DisconnectUrl"].ToString(CultureInfo.InvariantCulture) : "https://appcenter.intuit.com/api/v1/Connection/Disconnect";
        }



        
    }
    
}