using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Mvc3Layout.Models;

namespace Mvc3Layout.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
   
            // Get tokens from the AppSettings in config files
            ViewBag.applicationToken = ApplicationUserAppValues.ApplicationToken;
            ViewBag.consumerKey = ApplicationUserAppValues.ConsumerKey;
            ViewBag.consumerSecret = ApplicationUserAppValues.ConsumerSecret;
            ViewBag.Flag = SessionWrapper.Flag;

            if (string.IsNullOrWhiteSpace(ViewBag.applicationToken) || string.IsNullOrWhiteSpace(ViewBag.consumerKey) || string.IsNullOrWhiteSpace(ViewBag.consumerSecret))
            {
                return View();
            }
            else
            {
                return RedirectToAction("About", "Home");
            }
        }


        //
        // GET: /About/

        public ActionResult About()
        {
            //////just test
            //SessionWrapper.FriendlyEmail = "hhh";
            //SessionWrapper.FriendlyName = "hheeh";
            //SessionWrapper.FriendlyIdentifier = "wwrwe";

            return View();
        }

    }
}
