using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc3Layout.Models;

namespace Mvc3Layout.Controllers
{
    public class CleanupOnDisconnectController : Controller
    {
        //
        // GET: /CleanupOnDisconnect/

        public ActionResult CleanUp()
        {
            //perform the clean up here 

            // Redirect to Default.aspx when user clicks on ConenctToIntuit widget.
            
            object value = SessionWrapper.RedirectToDefault;
            if (value != null)
            {
                bool isTrue = (bool)value;
                if (isTrue)
                {
                    return RedirectToAction("About", "Home");
                }
            }
            return View();
        }

    }
}
