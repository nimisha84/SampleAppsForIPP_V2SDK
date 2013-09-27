using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Globalization;

namespace Mvc3Layout.Models
{
    internal class ApplicationUserAppValues
    {

        internal static string ApplicationToken
        {
            get
            {
                return ConfigurationManager.AppSettings["applicationToken"];
            }
        }

        internal static string ConsumerKey
        {
            get
            {
                return ConfigurationManager.AppSettings["consumerKey"];
            }
        }

        internal static string ConsumerSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["consumerSecret"];
            }
        }

        internal static string Oauth_callback_url
        {
            get
            {
                return ConfigurationManager.AppSettings["oauth_callback_url"];
            }
        }

        internal static string MenuProxy
        {
            get
            {
                return ConfigurationManager.AppSettings["menuProxy"];
            }
        }

        internal static string GrantUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["grantUrl"];
            }
        }



        internal class OpenIdUrl
        {
            /// <summary>
            /// Url Request Token
            /// </summary>
            internal static string OpenId_Identifier = ConfigurationManager.AppSettings["openid_identifier"] != null ?
                ConfigurationManager.AppSettings["openid_identifier"].ToString(CultureInfo.InvariantCulture) : "https://openid.intuit.com/Identity-YourAppName";


        }
    }
}