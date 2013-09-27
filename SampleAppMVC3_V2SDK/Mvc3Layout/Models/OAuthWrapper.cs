using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace Mvc3Layout.Models
{
    public class OAuthWrapper
    {

        /// <summary>
        /// Creates Session
        /// </summary>
        /// <returns>Returns OAuth Session</returns>
        public static String getOauthLinkforRedirect (String oauth_callback_url)
        {
            string FinaloauthLink,oauthLink, RequestToken, TokenSecret;

       
            oauthLink = Constants.OauthEndPoints.IdFedOAuthBaseUrl;
            //nimisha check
            //IToken token = (IToken)sessObj.RequestToken;
            IToken token = (IToken)HttpContext.Current.Session["requestToken"];
            IOAuthSession session = CreateSession(oauth_callback_url, oauthLink);
            IToken requestToken = session.GetRequestToken();
            HttpContext.Current.Session["requestToken"] = requestToken;
            RequestToken = requestToken.Token;
            TokenSecret = requestToken.TokenSecret;
            FinaloauthLink = Constants.OauthEndPoints.AuthorizeUrl + "?oauth_token=" + RequestToken + "&oauth_callback=" + UriUtility.UrlEncode(oauth_callback_url);
            return FinaloauthLink;
        }






        /// <summary>
        /// Creates Session
        /// </summary>
        /// <returns>Returns OAuth Session</returns>
        private static IOAuthSession CreateSession(String oauth_callback_url, String oauthLink)
        {
            

            OAuthConsumerContext consumerContext = new OAuthConsumerContext
            {
                ConsumerKey = ApplicationUserAppValues.ConsumerKey,
                ConsumerSecret = ApplicationUserAppValues.ConsumerSecret,
                SignatureMethod = SignatureMethod.HmacSha1
            };
            return new OAuthSession(consumerContext,
                                            Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
                                            oauthLink,
                                            Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);
        }
    }
}