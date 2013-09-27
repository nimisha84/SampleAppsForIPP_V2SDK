using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using System.Web.Mvc;
using Intuit.Ipp.Core;
using Mvc3Layout.Models;

namespace Mvc3Layout.Controllers
{
    public class OAuthHandlerController : Controller
    {
        //
        // GET: /OAuthHandler/

        public ActionResult OAuthHandler()
        {
            string _oauthVerifyer, _realmid;

            SessionWrapper sessObj = new SessionWrapper();
            if (Request.QueryString.HasKeys())
            {
                // This value is used to Get Access Token.
                _oauthVerifyer = Request.QueryString["oauth_verifier"].ToString(CultureInfo.InvariantCulture);

                _realmid = Request.QueryString["realmId"].ToString(CultureInfo.InvariantCulture);
                Session["realm"] = _realmid;

                //If dataSource is QBO call QuickBooks Online Services, else call QuickBooks Desktop Services
                switch (Request.QueryString["dataSource"].ToString(CultureInfo.InvariantCulture))
                {
                    case "QBO":
                        SessionWrapper.IntuitServiceType = IntuitServicesType.QBO.ToString();
                        break;
                    default:
                        SessionWrapper.IntuitServiceType = IntuitServicesType.QBD.ToString();
                        break;
                }

                //Stored in a session for demo purposes.
                //Production applications should securely store the Access Token
                OauthHandlerWrapper.getAccessToken(_oauthVerifyer);

                // This value is used to redirect to Default.aspx from Cleanup page when user clicks on ConnectToInuit widget.
                SessionWrapper.RedirectToDefault = "true";
            }
            else
            {
                Response.Write("No OAuth token was received");
            }


            return View();
            //return RedirectToAction("About", "Home");
        }
    }

    
}
