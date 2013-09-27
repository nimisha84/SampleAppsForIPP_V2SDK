using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;


namespace Mvc3Layout.Models
{
    internal class SessionWrapper
    {
        internal static string Flag
        {
            get
            {
                var flag = HttpContext.Current.Session["Flag"];
                return flag == null ? "" : flag.ToString();
            }
            set
            {
                HttpContext.Current.Session["Flag"] = value;
            }
        }


        internal static int SessionKeysCount
        {
            get
            {
                int sessionKeyCount = HttpContext.Current.Session.Keys.Count;
                return sessionKeyCount;
            }
           
        }



        internal static string OpenIdResponse
        {
            get
            {
                var openIdResponse = HttpContext.Current.Session["OpenIdResponse"];
                return openIdResponse == null ? "" : openIdResponse.ToString();
            }
            set
            {
                HttpContext.Current.Session["OpenIdResponse"] = value;
            }
        }


        internal static string FriendlyIdentifier
        {
            get
            {
                var friendlyIdentifier = HttpContext.Current.Session["FriendlyIdentifier"];
                return friendlyIdentifier == null ? "" : friendlyIdentifier.ToString();
            }
            set
            {
                HttpContext.Current.Session["FriendlyIdentifier"] = value;
            }
        }

        internal  static string FriendlyName
        {
            get
            {
                var friendlyName = HttpContext.Current.Session["FriendlyName"];
                return friendlyName == null ? "" : friendlyName.ToString();
            }
            set
            {
                HttpContext.Current.Session["FriendlyName"] = value;
            }
        }


        internal static string FriendlyEmail
        {
            get
            {
                var friendlyEmail = HttpContext.Current.Session["FriendlyEmail"];
                return friendlyEmail == null ? "" : friendlyEmail.ToString();
            }
            set
            {
                HttpContext.Current.Session["FriendlyEmail"] = value;
            }
        }

        internal static string accessToken
        {
            get
            {
                var _accessToken = HttpContext.Current.Session["accessToken"];
                return _accessToken == null ? "" : _accessToken.ToString();
            }
            set
            {
                HttpContext.Current.Session["accessToken"] = value;
            }
        }


        internal static string accessTokenSecret
        {
            get
            {
                var _accessTokenSecret = HttpContext.Current.Session["accessTokenSecret"];
                return _accessTokenSecret == null ? "" : _accessTokenSecret.ToString();
            }
            set
            {
                HttpContext.Current.Session["accessTokenSecret"] = value;
            }
        }

        internal static string InvalidAccessToken
        {
            get
            {
                var invalidAccessToken = HttpContext.Current.Session["InvalidAccessToken"];
                return invalidAccessToken == null ? "" : invalidAccessToken.ToString();
            }
            set
            {
                HttpContext.Current.Session["InvalidAccessToken"] = value;
            }
        }

        internal static string RedirectToDefault
        {
            get
            {
                var redirectToDefault = HttpContext.Current.Session["RedirectToDefault"];
                return redirectToDefault == null ? "" : redirectToDefault.ToString();
            }
            set
            {
                HttpContext.Current.Session["RedirectToDefault"] = value;
            }
        }


        internal static string ServiceEndPoint
        {
            get
            {
                var serviceEndPoint = HttpContext.Current.Session["ServiceEndPoint"];
                return serviceEndPoint == null ? "" : serviceEndPoint.ToString();
            }
            set
            {
                HttpContext.Current.Session["ServiceEndPoint"] = value;
            }
        }

        internal static string IntuitServiceType
        {
            get
            {
                var intuitServiceType = HttpContext.Current.Session["IntuitServiceType"];
                return intuitServiceType == null ? "" : intuitServiceType.ToString();
            }
            set
            {
                HttpContext.Current.Session["IntuitServiceType"] = value;
            }
        }



        //public HttpSessionState RequestToken
        //{
         
        //    get
        //    {
        //        //check if all need to be converted to httpsessionstate nimisha
        //        var requestToken = HttpContext.Current.Session["RequestToken"];
        //        return (HttpContext)requestToken;
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["RequestToken"] = value;
        //    }
        //}
     
    }
}