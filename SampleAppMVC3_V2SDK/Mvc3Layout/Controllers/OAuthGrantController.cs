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
    public class OAuthGrantController : Controller
    {
        //
        // GET: /OAuthGrant/

        public ActionResult OAuthGrant()
        {
            string oauth_callback_url, oauthLink;
           

            oauth_callback_url = Request.Url.GetLeftPart(UriPartial.Authority) + ApplicationUserAppValues.Oauth_callback_url;
            oauthLink = OAuthWrapper.getOauthLinkforRedirect(oauth_callback_url);
            //Response.Redirect(oauthLink);
            return Redirect(oauthLink);
        }

    }
}
