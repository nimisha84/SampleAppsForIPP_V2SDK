using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using Mvc3Layout.Models;

namespace Mvc3Layout.Controllers
{
    public class DisconnectController : Controller
    {

        /// <summary>        
        /// Creates a HttpRequest with oAuthSession (OAuth Token) and gets the response with invalidating user
        /// from QuickBooks for this app
        /// For Authorization: The request header must include the OAuth parameters defined by OAuth Core 1.0 Revision A.
        /// 
        /// If the disconnect is successful, then the HTTP status code is 200 and 
        /// the XML response includes the <ErrorCode> element with a 0 value.  
        /// If an HTTP error is detected, then the HTTP status code is not 200.  
        /// If an HTTP error is not detected but the disconnect is unsuccessful, 
        /// then the HTTP status code is 200 and the response XML includes the <ErrorCode> element with a non-zero value.   
        /// For example,  if the OAuth access token expires or is invalid for some other reason, then the value of <ErrorCode> is 270.
        /// </summary>
        //
        // GET: /CleanUpOnDisconnect/

        public ActionResult Disconnect()
        {
            

            OAuthConsumerContext consumerContext = new OAuthConsumerContext
           {
               ConsumerKey = ApplicationUserAppValues.ConsumerKey,
               SignatureMethod = SignatureMethod.HmacSha1,
               ConsumerSecret = ApplicationUserAppValues.ConsumerSecret
           };

            OAuthSession oSession = new OAuthSession(consumerContext, Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
                                  Constants.OauthEndPoints.AuthorizeUrl,
                                  Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);

            oSession.ConsumerContext.UseHeaderForOAuthParameters = true;
            if ((SessionWrapper.accessToken + "").Length > 0)
            {
                oSession.AccessToken = new TokenBase
                {
                    Token = SessionWrapper.accessToken,
                    ConsumerKey = ApplicationUserAppValues.ConsumerKey,
                    TokenSecret = SessionWrapper.accessTokenSecret
                };

                IConsumerRequest conReq = oSession.Request();
                conReq = conReq.Get();
                conReq = conReq.ForUrl(Constants.IaEndPoints.DisconnectUrl);
                try
                {
                    conReq = conReq.SignWithToken();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                //Used just see the what header contains
                string header = conReq.Context.GenerateOAuthParametersForHeader();

                //This method will clean up the OAuth Token
                GlobalVariablesWrapper.TxtServiceResponse = conReq.ReadBody();

                // Add the invalid access token into session for the display of the Disconnect btn
                SessionWrapper.InvalidAccessToken = SessionWrapper.accessToken;

                // Dont remove the access token since this is required for Reconnect btn in the Blue dot menu
                // HttpContext.Current.Session.Remove("accessToken");

                // Dont Remove flag since we need to display the blue dot menu for Reconnect btn in the Blue dot menu
                // HttpContext.Current.Session.Remove("Flag");
                GlobalVariablesWrapper.DisconnectFlg = "User is Disconnected from QuickBooks!";

               
            }
            return View("Disconnect");
        }
    }
}
