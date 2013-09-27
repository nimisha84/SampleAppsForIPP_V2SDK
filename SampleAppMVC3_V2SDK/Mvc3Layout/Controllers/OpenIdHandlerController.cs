using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc3Layout.Models;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace Mvc3Layout.Controllers
{
    public class OpenIdHandlerController : Controller
    {
        //
        // GET: /OpenIdHandler/

        /// <summary>
        /// This flow is invoked when the the user selects a QuickBooks company and then clicks Authorize to 
        /// grant this app access to that company's data. 
        /// Behind the scenes, this app exchanges tokens with the Intuit OAuth service and then 
        /// stores the authorized access token in a session store. (use persistent store such as a database in real time scenarios.)  
        /// A valid access token indicates that the user has connected your app to a specific company.  
        /// (Connections are important because Intuit charges you according to how many active connections 
        /// users have made with your app.)  Later, when your app calls Data Services for QuickBooks, 
        /// it fetches the access token from the persistent store and includes the token in the 
        /// HTTP request header.  
        /// </summary>

        ////public ActionResult Index()
        ////{
        ////    return View();
        ////}

        public ActionResult OpenIDHandler()
        {
        
            
            //OpenId Relying Party
            OpenIdRelyingParty openid = new OpenIdRelyingParty();

            var openIdIdentifier = ApplicationUserAppValues.OpenIdUrl.OpenId_Identifier;
            var response = openid.GetResponse();
            if (response == null)
            {
                // Stage 2: user submitting Identifier
                Identifier id;
                if (Identifier.TryParse(openIdIdentifier, out id))
                {
                    //see alternative for try catch using filter and ELMAH(error logging modules and handlers) nuget libaray
                    try
                    {
                        IAuthenticationRequest request = openid.CreateRequest(openIdIdentifier);
                        FetchRequest fetch = new FetchRequest();
                        fetch.Attributes.Add(new AttributeRequest(WellKnownAttributes.Contact.Email));
                        fetch.Attributes.Add(new AttributeRequest(WellKnownAttributes.Name.FullName));
                        request.AddExtension(fetch);
                        request.RedirectToProvider();
                    }
                    catch (ProtocolException ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                if (response.FriendlyIdentifierForDisplay == null)
                {
                    return RedirectToAction("OpenIDHandler", "OpenIDHandler");
                }

                // Stage 3: OpenID Provider sending assertion response
                SessionWrapper.FriendlyIdentifier = response.FriendlyIdentifierForDisplay;
                FetchResponse fetch = response.GetExtension<FetchResponse>();
                if (fetch != null)
                {
                    SessionWrapper.OpenIdResponse = "True";
                    SessionWrapper.FriendlyEmail = fetch.GetAttributeValue(WellKnownAttributes.Contact.Email);
                    SessionWrapper.FriendlyName = fetch.GetAttributeValue(WellKnownAttributes.Name.FullName);
                }

                //Check if user disconnected from the App Center
                if (Request.QueryString["disconnect"] != null && Request.QueryString["disconnect"].ToString(CultureInfo.InvariantCulture) == "true")
                {
                    //change flag to boolean type later
                    SessionWrapper.Flag = "true";
                    return RedirectToAction("CleanUp", "CleanupOnDisconnect");
                    //implement nimisha
                    ////Response.Redirect("CleanupOnDisconnect.aspx");
                }
                else
                {
                    return RedirectToAction("About", "Home");
                }
            }

            return View("OpenIDHandler");
        }

       
    }
}
