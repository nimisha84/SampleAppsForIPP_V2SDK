using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using Mvc3Layout.Models;
using System.Net;
using System.IO;

namespace Mvc3Layout.Controllers
{
    public class MenuProxyController : Controller
    {
        //
        // GET: /MenuProxy/

        public ActionResult Index()
        {            
            return RedirectToAction("GetBlueDotMenu");
        }

        public ActionResult GetBlueDotMenu()
        {
            SessionWrapper sessObj = new SessionWrapper();
            GlobalVariablesWrapper glblObj = new GlobalVariablesWrapper();
            ApplicationUserAppValues usrAppObj = new ApplicationUserAppValues();


            SessionWrapper.ServiceEndPoint = Constants.IaEndPoints.BlueDotAppMenuUrl;
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

            oSession.AccessToken = new TokenBase
            {
                Token = SessionWrapper.accessToken,
                ConsumerKey = ApplicationUserAppValues.ConsumerKey,
                TokenSecret = SessionWrapper.accessTokenSecret
            };

            IConsumerRequest conReq = oSession.Request();
            conReq = conReq.Get();
            conReq = conReq.ForUrl(SessionWrapper.ServiceEndPoint);
            try
            {
                conReq = conReq.SignWithToken();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string header = conReq.Context.GenerateOAuthParametersForHeader();
            try
            {

                GlobalVariablesWrapper.TxtServiceResponseForMenu = conReq.ReadBody();
                //check alternative but this should work nimisha
                Response.Write(GlobalVariablesWrapper.TxtServiceResponseForMenu);
            }
            catch (WebException we)
            {
                HttpWebResponse rsp = (HttpWebResponse)we.Response;
                if (rsp != null)
                {
                    try
                    {
                        using (StreamReader reader = new StreamReader(rsp.GetResponseStream()))
                        {
                            GlobalVariablesWrapper.TxtServiceResponseForMenu = GlobalVariablesWrapper.TxtServiceResponseForMenu + rsp.StatusCode + " | " + reader.ReadToEnd();
                        }
                    }
                    catch (Exception)
                    {
                        GlobalVariablesWrapper.TxtServiceResponseForMenu = GlobalVariablesWrapper.TxtServiceResponseForMenu + "Status code: " + rsp.StatusCode;
                    }
                }
                else
                {
                    GlobalVariablesWrapper.TxtServiceResponseForMenu = GlobalVariablesWrapper.TxtServiceResponseForMenu + "Error Communicating with Intuit Anywhere" + we.Message;
                }
            }

            return View("GetBlueDotMenu");
        }
    }
}
