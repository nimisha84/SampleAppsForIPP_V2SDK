using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;


namespace Mvc3Layout.Models
{
    public class OpenIdDisplay
    {
        //[DisplayName("Welcome:")]
        public string friendlyName { get; set; }
        //[DisplayName("E-mail Address:")]
        public string friendlyEmail { get; set; }
        //[DisplayName("Friendly Identifier:")]
        public string friendlyIdentifier { get; set; }
    }
}