using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using System.Globalization;

namespace Mvc3Layout.Models
{
    public class OauthHandlerWrapper
    {
        /// <summary>
        /// Gets the Access Token
        /// </summary>
        public static void getAccessToken(string _oauthVerifyer)
        {

            IOAuthSession clientSession = CreateSession();
            try
            {
                IToken accessToken = clientSession.ExchangeRequestTokenForAccessToken((IToken)HttpContext.Current.Session["requestToken"], _oauthVerifyer);
                SessionWrapper.accessToken = accessToken.Token;

                // Add flag to session which tells that accessToken is in session
                SessionWrapper.Flag = "true";
                SessionWrapper.InvalidAccessToken = "";
                // Remove the Invalid Access token since we got the new access token
                //HttpContext.Current.Session.Remove("InvalidAccessToken");

                SessionWrapper.accessTokenSecret = accessToken.TokenSecret;
            }
            catch (Exception ex)
            {
                //Handle Exception if token is rejected or exchange of Request Token for Access Token failed. 
                throw ex;
            }
        }



        /// <summary>
        /// Creates the OAuth Session using Consumer key
        /// </summary>        
        /// <returns>OAuth Session.</returns>
        private static IOAuthSession CreateSession()
        {
         

            OAuthConsumerContext consumerContext = new OAuthConsumerContext
            {
                ConsumerKey = ApplicationUserAppValues.ConsumerKey.ToString(CultureInfo.InvariantCulture),
                ConsumerSecret = ApplicationUserAppValues.ConsumerSecret.ToString(CultureInfo.InvariantCulture),
                SignatureMethod = SignatureMethod.HmacSha1
            };

            return new OAuthSession(consumerContext,
                                            Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
                                            Constants.OauthEndPoints.IdFedOAuthBaseUrl,
                                             Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);
        }
    }
}